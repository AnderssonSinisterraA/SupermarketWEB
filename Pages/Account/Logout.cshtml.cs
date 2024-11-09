using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;

public class LogoutModel : PageModel
{
    public async Task<IActionResult> OnPostAsync()
    {
        await HttpContext.SignOutAsync("MyCookieAuth");
        return RedirectToPage("/Account/Login");
    }
}
