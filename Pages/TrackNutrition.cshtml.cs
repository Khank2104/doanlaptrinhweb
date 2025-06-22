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
    public class TrackNutritionModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TrackNutritionModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public List<NutritionLog> TodayMeals { get; set; } = new();
        public List<SavedMealSuggestion> SavedSuggestions { get; set; } = new();

        public int TotalCalories { get; set; }
        public float TotalProtein { get; set; }
        public float TotalCarbs { get; set; }
        public float TotalFat { get; set; }

        [BindProperty]
        public NutritionInputModel Input { get; set; } = new();

        public class NutritionInputModel
        {
            [Required]
            public string MealType { get; set; } = "";

            [Required]
            public string FoodName { get; set; } = "";

            [Range(0, 10000)]
            public int Calories { get; set; }

            [Range(0, 1000)]
            public float Protein { get; set; }

            [Range(0, 1000)]
            public float Carbs { get; set; }

            [Range(0, 1000)]
            public float Fat { get; set; }

            [DataType(DataType.Date)]
            public DateTime LogDate { get; set; } = DateTime.Today;

            [DataType(DataType.Time)]
            public TimeSpan LogTime { get; set; } = DateTime.Now.TimeOfDay;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var userId = _userManager.GetUserId(User);

            // 1. Lấy toàn bộ dữ liệu hôm nay từ DB (chỉ điều kiện đơn giản)
            TodayMeals = await _context.NutritionLogs
                .Where(n => n.UserId == userId && n.LogDate.Date == DateTime.Today)
                .ToListAsync();

            // 2. Sau đó mới sắp xếp theo giờ ăn + ngày (trên client)
            TodayMeals = TodayMeals
                .OrderByDescending(n => n.LogDate.Date + n.LogTime)
                .ToList();

            // 3. Tổng hợp chỉ số
            TotalCalories = TodayMeals.Sum(m => m.Calories);
            TotalProtein = TodayMeals.Sum(m => m.Protein);
            TotalCarbs = TodayMeals.Sum(m => m.Carbs);
            TotalFat = TodayMeals.Sum(m => m.Fat);

            SavedSuggestions = await _context.SavedMealSuggestions
                .Where(s => s.UserId == userId)
                .OrderByDescending(s => s.SavedAt)
                .Take(5)
                .ToListAsync();


            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return await OnGetAsync();

            var userId = _userManager.GetUserId(User);

            var log = new NutritionLog
            {
                UserId = userId!,
                MealType = Input.MealType,
                FoodName = Input.FoodName,
                Calories = Input.Calories,
                Protein = Input.Protein,
                Carbs = Input.Carbs,
                Fat = Input.Fat,
                LogDate = Input.LogDate,
                LogTime = Input.LogTime
            };

            _context.NutritionLogs.Add(log);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "🥗 Đã ghi nhận món ăn!";
            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var log = await _context.NutritionLogs.FindAsync(id);
            if (log == null) return NotFound();

            var userId = _userManager.GetUserId(User);
            if (log.UserId != userId)
                return Forbid();

            _context.NutritionLogs.Remove(log);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "🗑️ Đã xóa thành công!";
            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostQuickLogAsync(
    string FoodName, string MealType, int Calories, float Protein, float Carbs, float Fat)
        {
            var userId = _userManager.GetUserId(User);

            var log = new NutritionLog
            {
                UserId = userId!,
                MealType = MealType,
                FoodName = FoodName,
                Calories = Calories,
                Protein = Protein,
                Carbs = Carbs,
                Fat = Fat,
                LogDate = DateTime.Today,
                LogTime = DateTime.Now.TimeOfDay
            };

            _context.NutritionLogs.Add(log);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "📌 Đã ghi nhận bữa ăn từ gợi ý!";
            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostSaveSuggestionAsync(
    string FoodName, string MealType, int Calories, float Protein, float Carbs, float Fat)
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null) return Unauthorized();

            // Tạo gợi ý
            var suggestion = new SavedMealSuggestion
            {
                UserId = userId,
                FoodName = FoodName,
                MealType = MealType,
                Calories = Calories,
                Protein = Protein,
                Carbs = Carbs,
                Fat = Fat,
                SavedAt = DateTime.Now
            };

            // Lưu vào DB
            _context.SavedMealSuggestions.Add(suggestion);
            await _context.SaveChangesAsync();

            // Gửi thông báo và chuyển hướng về TrackNutrition
            TempData["SuccessMessage"] = "⭐ Gợi ý món ăn đã được lưu! Bạn có thể ghi nhận nhanh từ danh sách.";
            return RedirectToPage("/TrackNutrition");
        }



    }
}
