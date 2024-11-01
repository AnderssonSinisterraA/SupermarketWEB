using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

// Alias para el espacio de nombres
using PayModeModel = SupermarketWEB.Models.PayMode;

namespace SupermarketWEB.Pages.PayModes
{
    public class DeleteModel : PageModel
    {
        private readonly SupermarketContext _context;

        public DeleteModel(SupermarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PayModeModel PayMode { get; set; } = default;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PayModes == null)
            {
                return NotFound();
            }

            var payMode = await _context.PayModes.FindAsync(id);

            if (payMode != null)
            {
                PayMode = payMode;
                _context.PayModes.Remove(payMode);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
