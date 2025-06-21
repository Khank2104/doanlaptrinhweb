using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SmartGym.Data;
using SmartGym.Models;
using System.ComponentModel.DataAnnotations;

namespace SmartGym.Pages
{
    [Authorize]
    public class TrackWorkoutModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TrackWorkoutModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public class ChartPoint
        {
            public string DayLabel { get; set; } = "";
            public double Calories { get; set; }
        }

        public List<ChartPoint> ChartData { get; set; } = new();


        [BindProperty]
        public WorkoutInputModel Input { get; set; } = new();

        public List<WorkoutActivity> TodaysActivities { get; set; } = new();
        public List<SavedExerciseSuggestion> SavedSuggestions { get; set; } = new();
        public int TotalMinutes { get; set; }
        public double TotalCalories { get; set; }

        // ✅ Thêm property lưu UserFitnessProfile
        public UserFitnessProfile? UserProfile { get; set; }


        public class WorkoutInputModel
        {
            [Required]
            public string ActivityType { get; set; } = string.Empty;

            [Range(1, 1000)]
            public int DurationMinutes { get; set; }

            [Range(0, 10000)]
            public double CaloriesBurned { get; set; }

            [DataType(DataType.Date)]
            public DateTime ActivityDate { get; set; } = DateTime.Today;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var userId = _userManager.GetUserId(User);
            ChartData = await _context.WorkoutActivities
                .Where(a => a.UserId == userId && a.ActivityDate >= DateTime.Today.AddDays(-6))
                .GroupBy(a => a.ActivityDate.Date)
                .OrderBy(g => g.Key)
                .Select(g => new ChartPoint
                {
                    DayLabel = g.Key.ToString("dd/MM"),
                    Calories = g.Sum(a => a.CaloriesBurned)
                })
                .ToListAsync();

            // Load hoạt động hôm nay như cũ...
            TodaysActivities = await _context.WorkoutActivities
                .Where(a => a.UserId == userId && a.ActivityDate.Date == DateTime.Today)
                .ToListAsync();

            TotalMinutes = TodaysActivities.Sum(a => a.DurationMinutes);
            TotalCalories = TodaysActivities.Sum(a => a.CaloriesBurned);

            // ✅ Load bài tập đã lưu
            SavedSuggestions = await _context.SavedExerciseSuggestions
                .Where(s => s.UserId == userId)
                .OrderByDescending(s => s.SavedAt)
                .Take(5) // chỉ lấy 5 bài tập gần nhất
                .ToListAsync();

            // ✅ Load hồ sơ người dùng
            UserProfile = await _context.UserFitnessProfiles
                .FirstOrDefaultAsync(p => p.UserId == userId);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return await OnGetAsync();

            var userId = _userManager.GetUserId(User);
            var activity = new WorkoutActivity
            {
                UserId = userId!,
                ActivityType = Input.ActivityType,
                DurationMinutes = Input.DurationMinutes,
                CaloriesBurned = Input.CaloriesBurned,
                ActivityDate = Input.ActivityDate
            };

            _context.WorkoutActivities.Add(activity);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "✅ Đã ghi nhận hoạt động!";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var userId = _userManager.GetUserId(User);
            var activity = await _context.WorkoutActivities
                .FirstOrDefaultAsync(a => a.Id == id && a.UserId == userId);

            if (activity != null)
            {
                _context.WorkoutActivities.Remove(activity);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "🗑️ Đã xoá hoạt động!";
            }

            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostQuickLogAsync(string Name, int Duration, double Calories)
        {
            var userId = _userManager.GetUserId(User);
            var activity = new WorkoutActivity
            {
                UserId = userId!,
                ActivityType = Name,
                DurationMinutes = Duration,
                CaloriesBurned = Calories,
                ActivityDate = DateTime.Today
            };

            _context.WorkoutActivities.Add(activity);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "✅ Đã ghi nhận bài tập từ gợi ý!";
            return RedirectToPage();
        }

    }
}
