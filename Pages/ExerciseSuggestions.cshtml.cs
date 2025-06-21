using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SmartGym.Data;
using SmartGym.Models;

namespace SmartGym.Pages;

[Authorize]
public class ExerciseSuggestionsModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public ExerciseSuggestionsModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [BindProperty]
    public string Goal { get; set; } = string.Empty;

    [BindProperty]
    public double BMI { get; set; }

    [BindProperty]
    public string Level { get; set; } = "người mới";

    public IList<ExerciseSuggestion> Suggestions { get; set; } = new List<ExerciseSuggestion>();

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
            TempData["Error"] = "Bạn chưa có hồ sơ thể chất. Hãy cập nhật trước!";
            return RedirectToPage("/Profile");
        }

        Goal = profile.Goal;
        BMI = profile.BMI;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        IsPost = true;

        if (!ModelState.IsValid)
        {
            return await OnGetAsync();
        }

        Suggestions = await _context.ExerciseSuggestions
            .Where(e => e.Goal == Goal && e.Level == Level && e.BmiMin <= BMI && BMI <= e.BmiMax)
            .Take(4)
            .ToListAsync();

        return Page();
    }

    // ✅ Handler lưu gợi ý bài tập
    public async Task<IActionResult> OnPostSaveAsync(string name, string goal, string level, int duration, double calories)
    {
        var userId = _userManager.GetUserId(User);

        var exists = await _context.SavedExerciseSuggestions
            .AnyAsync(e => e.UserId == userId && e.Name == name && e.Level == level);

        if (!exists)
        {
            var saved = new SavedExerciseSuggestion
            {
                UserId = userId!,
                Name = name,
                Goal = goal,
                Level = level,
                Duration = duration,
                CaloriesBurned = calories
            };

            _context.SavedExerciseSuggestions.Add(saved);
            await _context.SaveChangesAsync();

            SuccessMessage = "✅ Đã lưu bài tập!";
        }
        else
        {
            SuccessMessage = "⚠️ Bài tập đã tồn tại trong danh sách của bạn.";
        }

        return RedirectToPage();
    }
}
