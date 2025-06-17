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
    public class DeleteModel : PageModel
    {
        private readonly FallsTurismContext _context;

        public DeleteModel(FallsTurismContext context) {
            _context = context;
        }

        [BindProperty]
        public Cliente Cliente { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id) {
            if (id == null) {
                return NotFound();
            }

            var cliente = await _context.Clientes.FirstOrDefaultAsync(m => m.Id == id);

            if (cliente == null) {
                return NotFound();
            } else {
                Cliente = cliente;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id) {
            if (id == null) {
                return NotFound();
            }

            // Encontra o cliente no banco de dados
            var clienteToDelete = await _context.Clientes.FindAsync(id);

            if (clienteToDelete != null) {
                // Em vez de Remover, atualiza a propriedade DeletedAt
                clienteToDelete.DeletedAt = DateTime.UtcNow; 
                _context.Clientes.Update(clienteToDelete); // Marca o objeto como modificado
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Clientes/List");
        }
    }
}
