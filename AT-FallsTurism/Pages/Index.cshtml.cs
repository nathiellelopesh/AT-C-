using AT_FallsTurism.Data;
using AT_FallsTurism.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AT_FallsTurism.Pages
{
    public class IndexModel : PageModel
    {
        private readonly FallsTurismContext _context;
        public IList<PacoteTuristico> PacotesTuristicos { get; set; } = default!;

        public IndexModel(FallsTurismContext context) {
            _context = context;
        }

        public async Task OnGetAsync() {
            if (_context.PacotesTuristicos != null) {

                PacotesTuristicos = await _context.PacotesTuristicos
                    .Include(p => p.Destinos)
                    .ToListAsync();
            }
        }
    }
}
