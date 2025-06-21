using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SmartGym.Data;
using SmartGym.Models;
using System;

namespace SmartGym.Pages
{
    [Authorize]
    public class DashboardModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public DashboardModel(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public ApplicationUser? UserProfile { get; private set; }

        public double BMI { get; private set; }
        public string BMICategory { get; private set; } = string.Empty;
        public string Recommendation { get; private set; } = string.Empty;
        public string Goal { get; private set; } = string.Empty;

        public double TotalWaterToday { get; private set; }  // ✅ thêm biến tổng lượng nước
        public double TotalSleepToday { get; private set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var userId = _userManager.GetUserId(User);
            if (string.IsNullOrEmpty(userId))
                return RedirectToPage("/Index");

            UserProfile = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (UserProfile == null)
                return RedirectToPage("/Index");

            var profile = await _context.UserFitnessProfiles
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.UserId == userId);

            if (profile != null)
            {
                BMI = profile.BMI;
                Goal = profile.Goal ?? "Chưa thiết lập";
            }
            else if (UserProfile.Height > 0)
            {
                BMI = UserProfile.Weight / Math.Pow(UserProfile.Height / 100.0, 2);
                Goal = "Chưa thiết lập";
            }

            // ✅ Tính lượng nước uống trong ngày hôm nay
            var today = DateTime.Today;
            TotalWaterToday = await _context.WaterIntakes
                .Where(w => w.UserId == userId && w.LogDate.Date == today)
                .SumAsync(w => w.AmountInLiters);

            // ✅ Tính tổng thời lượng ngủ hôm nay (SleepEnd phải nằm trong hôm nay)
            var sleepLogsToday = await _context.SleepLogs
                .Where(s => s.UserId == userId && s.SleepEnd.Date == today)
                .ToListAsync();

            TotalSleepToday = sleepLogsToday.Sum(s => (s.SleepEnd - s.SleepStart).TotalHours);

            // ✅ Phân loại BMI
            if (BMI < 18.5)
            {
                BMICategory = "Gầy";
                Recommendation = "Bạn nên tăng cân bằng chế độ ăn giàu dinh dưỡng và tập luyện vừa phải.";
            }
            else if (BMI < 25)
            {
                BMICategory = "Bình thường";
                Recommendation = "Bạn có thể duy trì chế độ sinh hoạt hiện tại. Rất tốt!";
            }
            else if (BMI < 30)
            {
                BMICategory = "Thừa cân";
                Recommendation = "Bạn nên kết hợp tập luyện và ăn uống hợp lý để giảm cân.";
            }
            else
            {
                BMICategory = "Béo phì";
                Recommendation = "Hãy thực hiện chế độ ăn nghiêm ngặt và tập luyện thường xuyên để cải thiện sức khỏe.";
            }

            return Page();
        }
    }
}
