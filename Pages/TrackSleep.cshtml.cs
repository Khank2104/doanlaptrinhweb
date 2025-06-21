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
    public class TrackSleepModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public TrackSleepModel(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [BindProperty]
        public SleepInputModel Input { get; set; } = new();

        public List<SleepLog> TodaysSleep { get; set; } = new();
        public double TotalHours { get; set; }

        public class SleepInputModel
        {
            [Required(ErrorMessage = "Vui lòng chọn thời gian đi ngủ.")]
            public DateTime SleepStart { get; set; }

            [Required(ErrorMessage = "Vui lòng chọn thời gian thức dậy.")]
            public DateTime SleepEnd { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToPage("/Index");

            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);

            TodaysSleep = await _context.SleepLogs
                .Where(s => s.UserId == user.Id && s.SleepEnd > today && s.SleepEnd <= tomorrow)
                .OrderByDescending(s => s.SleepStart)
                .ToListAsync();

            TotalHours = TodaysSleep.Sum(s => s.Duration.TotalHours);

            if (TotalHours < 6 && TotalHours > 0)
            {
                TempData["SleepWarning"] = "⚠️ Bạn nên ngủ ít nhất 6 tiếng để đảm bảo sức khoẻ!";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return await OnGetAsync();

            if (Input.SleepEnd <= Input.SleepStart)
            {
                ModelState.AddModelError(string.Empty, "Thời gian thức dậy phải sau thời gian đi ngủ.");
                return await OnGetAsync();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToPage("/Index");

            var log = new SleepLog
            {
                UserId = user.Id,
                SleepStart = Input.SleepStart,
                SleepEnd = Input.SleepEnd
            };

            _context.SleepLogs.Add(log);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "🛌 Đã ghi nhận giấc ngủ!";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToPage("/Index");

            var log = await _context.SleepLogs.FirstOrDefaultAsync(s => s.Id == id && s.UserId == user.Id);
            if (log != null)
            {
                _context.SleepLogs.Remove(log);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "🗑️ Đã xoá bản ghi!";
            }

            return RedirectToPage();
        }
    }
}
