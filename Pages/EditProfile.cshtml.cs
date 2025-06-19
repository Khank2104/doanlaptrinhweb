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
    public class EditProfileModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public EditProfileModel(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();

        public class InputModel
        {
            [Required(ErrorMessage = "Họ tên không được để trống")]
            public string FullName { get; set; } = string.Empty;

            [Required(ErrorMessage = "Ngày sinh không được để trống")]
            [DataType(DataType.Date)]
            public DateTime DateOfBirth { get; set; }

            [Required(ErrorMessage = "Chiều cao không được để trống")]
            [Range(50, 300, ErrorMessage = "Chiều cao phải trong khoảng 50-300 cm")]
            public double Height { get; set; }

            [Required(ErrorMessage = "Cân nặng không được để trống")]
            [Range(20, 300, ErrorMessage = "Cân nặng phải trong khoảng 20-300 kg")]
            public double Weight { get; set; }

            [Required(ErrorMessage = "Giới tính không được để trống")]
            public string Gender { get; set; } = "";

            [Required(ErrorMessage = "Mục tiêu không được để trống")]
            public string Goal { get; set; } = "Giữ dáng";
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                TempData["ErrorMessage"] = "Không thể xác định người dùng!";
                return RedirectToPage("/Index");
            }

            var profile = await _context.UserFitnessProfiles
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.UserId == user.Id);

            Input = new InputModel
            {
                FullName = user.FullName,
                DateOfBirth = user.DateOfBirth,
                Height = user.Height,
                Weight = user.Weight,
                Gender = user.Gender,
                Goal = profile?.Goal ?? "Giữ dáng"
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // In log để dễ debug nếu có lỗi
                foreach (var field in ModelState)
                {
                    foreach (var error in field.Value.Errors)
                    {
                        Console.WriteLine($"❌ {field.Key}: {error.ErrorMessage}");
                    }
                }

                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                TempData["ErrorMessage"] = "Người dùng không tồn tại!";
                return RedirectToPage("/Index");
            }

            double bmi = Input.Weight / Math.Pow(Input.Height / 100.0, 2);
            bool isChanged = user.Height != Input.Height || user.Weight != Input.Weight;

            // Cập nhật người dùng
            user.FullName = Input.FullName;
            user.DateOfBirth = Input.DateOfBirth;
            user.Height = Input.Height;
            user.Weight = Input.Weight;
            user.Gender = Input.Gender;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, $"Lỗi khi cập nhật: {err.Description}");
                }

                return Page();
            }

            // Cập nhật hoặc tạo mới hồ sơ tập luyện
            var profile = await _context.UserFitnessProfiles
                .FirstOrDefaultAsync(p => p.UserId == user.Id);

            if (profile == null)
            {
                _context.UserFitnessProfiles.Add(new UserFitnessProfile
                {
                    UserId = user.Id,
                    BMI = bmi,
                    Goal = Input.Goal,
                    CreatedAt = DateTime.Now
                });
            }
            else
            {
                profile.BMI = bmi;
                profile.Goal = Input.Goal;
                _context.UserFitnessProfiles.Update(profile);
            }

            // Ghi lại lịch sử sức khỏe
            if (isChanged)
            {
                _context.HealthHistories.Add(new HealthHistory
                {
                    UserId = user.Id,
                    Height = Input.Height,
                    Weight = Input.Weight,
                    BMI = bmi,
                    LoggedAt = DateTime.Now
                });
            }

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "✅ Thông tin đã cập nhật thành công!";
            return RedirectToPage("/Dashboard");
        }
    }
}
