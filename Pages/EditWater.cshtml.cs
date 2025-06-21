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
    public class EditWaterModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public EditWaterModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();

        public class InputModel
        {
            public int Id { get; set; }

            [Required(ErrorMessage = "Vui lòng nhập lượng nước")]
            [Range(10, 5000, ErrorMessage = "Giá trị từ 10ml đến 5000ml")]
            public int AmountInMilliliters { get; set; }

            [DataType(DataType.Date)]
            public DateTime LogDate { get; set; } = DateTime.Today;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToPage("/Index");

            var intake = await _context.WaterIntakes
                .AsNoTracking()
                .FirstOrDefaultAsync(w => w.Id == id && w.UserId == user.Id);

            if (intake == null)
                return NotFound();

            Input = new InputModel
            {
                Id = intake.Id,
                AmountInMilliliters = (int)(intake.AmountInLiters * 1000),
                LogDate = intake.LogDate
            };

            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            if (Input.LogDate > DateTime.Today)
            {
                ModelState.AddModelError("Input.LogDate", "Không thể chỉnh cho ngày tương lai.");
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToPage("/Index");

            var intake = await _context.WaterIntakes
                .FirstOrDefaultAsync(w => w.Id == Input.Id && w.UserId == user.Id);

            if (intake == null)
                return NotFound();

            intake.AmountInLiters = Input.AmountInMilliliters / 1000.0;
            intake.LogDate = Input.LogDate;

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "✅ Đã cập nhật lượng nước!";
            return RedirectToPage("/TrackWater");
        }

    }
}
