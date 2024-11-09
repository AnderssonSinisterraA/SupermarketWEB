using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using SupermarketWEB.Data;
using SupermarketWEB.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;

public class LoginModel : PageModel
{
    private readonly SupermarketContext _context;

    public LoginModel(SupermarketContext context)
    {
        _context = context;
    }

    [BindProperty]
    public User User { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            // Validar las credenciales del usuario contra la base de datos
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == User.Email && u.Password == User.Password);

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, User.Email)
                };

                var claimsIdentity = new ClaimsIdentity(claims, "MyCookieAuth");

                await HttpContext.SignInAsync("MyCookieAuth", new ClaimsPrincipal(claimsIdentity));

                return RedirectToPage("/Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Credenciales inválidas.");
            }
        }

        return Page();
    }
}
