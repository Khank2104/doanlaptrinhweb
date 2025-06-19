using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SmartGym.Data;
using SmartGym.Models;

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

            // Gán BMICategory và Recommendation từ BMI
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
