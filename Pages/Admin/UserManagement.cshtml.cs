using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartGym.Models;

namespace SmartGym.Pages.Admin;

[Authorize(Roles = "Admin")]
public class UserManagementModel : PageModel
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserManagementModel(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public List<ApplicationUser> Users { get; set; } = new();
    public Dictionary<string, IList<string>> UserRoles { get; set; } = new();

    public async Task OnGetAsync()
    {
        Users = _userManager.Users.ToList();

        UserRoles = new Dictionary<string, IList<string>>();

        foreach (var user in Users)
        {
            var roles = await _userManager.GetRolesAsync(user);
            UserRoles[user.Id] = roles;
        }
    }

    public async Task<IActionResult> OnPostGrantAdminAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null) return NotFound();

        if (!await _userManager.IsInRoleAsync(user, "Admin"))
        {
            await _userManager.AddToRoleAsync(user, "Admin");
        }

        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostRevokeAdminAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null) return NotFound();

        if (await _userManager.IsInRoleAsync(user, "Admin"))
        {
            await _userManager.RemoveFromRoleAsync(user, "Admin");
        }

        return RedirectToPage();
    }
}
