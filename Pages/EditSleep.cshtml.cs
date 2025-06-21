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
    public class EditSleepModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public EditSleepModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public SleepInputModel Input { get; set; } = new();

        public int SleepId { get; set; }

        public class SleepInputModel
        {
            [Required]
            public DateTime SleepStart { get; set; }

            [Required]
            public DateTime SleepEnd { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var userId = _userManager.GetUserId(User);
            var sleep = await _context.SleepLogs
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id && s.UserId == userId);

            if (sleep == null)
                return RedirectToPage("/TrackSleep");

            SleepId = id;
            Input = new SleepInputModel
            {
                SleepStart = sleep.SleepStart,
                SleepEnd = sleep.SleepEnd
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
                return Page();

            if (Input.SleepEnd <= Input.SleepStart)
            {
                ModelState.AddModelError(string.Empty, "Giờ thức dậy phải sau giờ đi ngủ.");
                return Page();
            }

            var userId = _userManager.GetUserId(User);
            var sleep = await _context.SleepLogs
                .FirstOrDefaultAsync(s => s.Id == id && s.UserId == userId);

            if (sleep == null)
                return RedirectToPage("/TrackSleep");

            sleep.SleepStart = Input.SleepStart;
            sleep.SleepEnd = Input.SleepEnd;

            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "✅ Cập nhật giấc ngủ thành công!";
            return RedirectToPage("/TrackSleep");
        }
    }
}
