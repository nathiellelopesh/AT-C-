
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AT_FallsTurism.Data;
using AT_FallsTurism.Models;

namespace AT_FallsTurism.Pages.Reservas
{
    public class ListaReservasModel : PageModel
    {
        private readonly FallsTurismContext _context;

        public ListaReservasModel(FallsTurismContext context)
        {
            _context = context;
        }

        public IList<Reserva> Reserva { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Reserva = await _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.PacoteTuristico).ToListAsync();
        }
    }
}
