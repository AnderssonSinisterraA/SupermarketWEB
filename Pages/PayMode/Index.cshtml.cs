using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
// Alias para el espacio de nombres
using PayModeModel = SupermarketWEB.Models.PayMode;

namespace SupermarketWEB.Pages.PayModes
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly SupermarketContext _context;

        public IndexModel(SupermarketContext context)
        {
            _context = context;
        }

        public IList<PayModeModel> PayModes { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.PayModes != null)
            {
                PayModes = await _context.PayModes.ToListAsync();
            }
        }
    }
}
