using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AT_FallsTurism.Data;
using AT_FallsTurism.Models;

namespace AT_FallsTurism.Pages.Reservas
{
    public class EditModel : PageModel
    {
        private readonly FallsTurismContext _context;

        public EditModel(FallsTurismContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Reserva Reserva { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                                .Include(r => r.Cliente) // Inclua o Cliente
                                .FirstOrDefaultAsync(m => m.Id == id);
            if (reserva == null)
            {
                return NotFound();
            }
            Reserva = reserva;
           ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Email");
           ViewData["PacoteTuristicoId"] = new SelectList(_context.PacotesTuristicos, "Id", "Titulo");
            return Page();
        }


        public async Task<IActionResult> OnPostAsync() {

            
            ModelState.Remove("Reserva.Cliente");
            ModelState.Remove("Reserva.PacoteTuristico");

            if (!ModelState.IsValid) {
                Console.WriteLine("Inválido");
                foreach (var modelStateEntry in ModelState.Values) {
                    foreach (var error in modelStateEntry.Errors) {
                        Console.WriteLine($"Erro: {error.ErrorMessage}");
                    }
                }

                var existingReserva = await _context.Reservas
                                                    .Include(r => r.Cliente)
                                                    .FirstOrDefaultAsync(r => r.Id == Reserva.Id);
                if (existingReserva != null) {
                    Reserva.Cliente = existingReserva.Cliente;
                }

                ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Email");
                ViewData["PacoteTuristicoId"] = new SelectList(_context.PacotesTuristicos, "Id", "Titulo");

                return Page();
            }

            Console.WriteLine("ClienteId: " + Reserva.ClienteId);
            Console.WriteLine("PacoteId: " + Reserva.PacoteTuristicoId);

            _context.Attach(Reserva).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservaExists(Reserva.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Reservas/ListaReservas");
        }

        private bool ReservaExists(int id)
        {
            return _context.Reservas.Any(e => e.Id == id);
        }
    }
}
