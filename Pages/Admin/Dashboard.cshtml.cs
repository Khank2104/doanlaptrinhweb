using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartGym.Data;
using SmartGym.Models;

namespace SmartGym.Pages.Admin;

[Authorize(Roles = "Admin")]
public class DashboardModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public DashboardModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public string Message { get; set; } = "🛠️ Trang tổng quan quản trị hệ thống!";
    public int TotalUsers { get; set; }
    public int TotalMealsLogged { get; set; }

    public void OnGet()
    {
        TotalUsers = _userManager.Users.Count();
        TotalMealsLogged = _context.NutritionLogs.Count();
    }
}
