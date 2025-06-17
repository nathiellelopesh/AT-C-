using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AT_FallsTurism.Data;
using AT_FallsTurism.Models;

namespace AT_FallsTurism.Pages.Clientes
{
    public class ListModel : PageModel
    {
        private readonly AT_FallsTurism.Data.FallsTurismContext _context;

        public ListModel(AT_FallsTurism.Data.FallsTurismContext context)
        {
            _context = context;
        }

        public IList<Cliente> Cliente { get;set; } = default!;

        public async Task OnGetAsync()
        {
            //Cliente = await _context.Clientes.ToListAsync();

            Cliente = await _context.Clientes
                                    .Where(c => c.DeletedAt == null)
                                    .ToListAsync();
        }
    }
}
