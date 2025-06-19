using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using SmartGym.Models;

namespace SmartGym.Pages
{
    public class IndexModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult OnGet()
        {
            // Nếu đã đăng nhập thì chuyển hướng tới Dashboard
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToPage("/Dashboard");
            }

            return Page();
        }
    }
}
