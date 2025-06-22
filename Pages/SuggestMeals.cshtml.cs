using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SmartGym.Data;
using SmartGym.Models;

namespace SmartGym.Pages;

[Authorize]
public class SuggestMealsModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public SuggestMealsModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [BindProperty]
    public string Goal { get; set; } = "";

    [BindProperty]
    public double BMI { get; set; }

    [BindProperty]
    public string Level { get; set; } = "người mới";

    public List<MealSuggestion> Suggestions { get; set; } = new();

    [TempData]
    public bool IsPost { get; set; }

    [TempData]
    public string? SuccessMessage { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        var userId = _userManager.GetUserId(User);
        var profile = await _context.UserFitnessProfiles.FirstOrDefaultAsync(p => p.UserId == userId);

        if (profile == null)
        {
            TempData["Error"] = "Bạn chưa có hồ sơ thể chất.";
            return RedirectToPage("/Profile");
        }

        Goal = profile.Goal;
        BMI = profile.BMI;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        IsPost = true;

        Suggestions = await _context.MealSuggestions
            .Where(m => m.GoalType == Goal && m.BmiMin <= BMI && BMI <= m.BmiMax)
            .Take(4)
            .ToListAsync();

        return Page();
    }

    public async Task<IActionResult> OnPostSaveAsync(string mealName, string goal, int calories, float protein, float carbs, float fat)
    {
        var userId = _userManager.GetUserId(User);

        var exists = await _context.SavedMealSuggestions
            .AnyAsync(s => s.UserId == userId && s.FoodName == mealName);

        if (!exists)
        {
            var suggestion = new SavedMealSuggestion
            {
                UserId = userId!,
                FoodName = mealName,
                MealType = "Gợi ý",
                Calories = calories,
                Protein = protein,
                Carbs = carbs,
                Fat = fat,
                SavedAt = DateTime.Now
            };

            _context.SavedMealSuggestions.Add(suggestion);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "⭐ Đã lưu bữa ăn vào danh sách gợi ý!";
        }
        else
        {
            TempData["SuccessMessage"] = "⚠️ Món ăn đã có trong danh sách gợi ý!";
        }

        return RedirectToPage("/TrackNutrition");
    }

}
