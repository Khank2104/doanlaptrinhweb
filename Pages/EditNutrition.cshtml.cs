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
    public class EditNutritionModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public EditNutritionModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public NutritionInputModel Input { get; set; } = new();

        public class NutritionInputModel
        {
            public int Id { get; set; }

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
            public DateTime LogDate { get; set; }

            [DataType(DataType.Time)]
            public TimeSpan LogTime { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var userId = _userManager.GetUserId(User);
            var log = await _context.NutritionLogs.FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);

            if (log == null) return NotFound();

            Input = new NutritionInputModel
            {
                Id = log.Id,
                MealType = log.MealType,
                FoodName = log.FoodName,
                Calories = log.Calories,
                Protein = log.Protein,
                Carbs = log.Carbs,
                Fat = log.Fat,
                LogDate = log.LogDate.Date,
                LogTime = log.LogTime
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var userId = _userManager.GetUserId(User);
            var log = await _context.NutritionLogs.FirstOrDefaultAsync(x => x.Id == Input.Id && x.UserId == userId);

            if (log == null) return NotFound();

            log.MealType = Input.MealType;
            log.FoodName = Input.FoodName;
            log.Calories = Input.Calories;
            log.Protein = Input.Protein;
            log.Carbs = Input.Carbs;
            log.Fat = Input.Fat;
            log.LogDate = Input.LogDate;
            log.LogTime = Input.LogTime;

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "✔️ Đã cập nhật món ăn!";
            return RedirectToPage("/TrackNutrition");
        }
    }
}
