using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWEB.Data;
using SupermarketWEB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

// Alias para el espacio de nombres
using PayModeModel = SupermarketWEB.Models.PayMode;
using Microsoft.AspNetCore.Authorization;

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
