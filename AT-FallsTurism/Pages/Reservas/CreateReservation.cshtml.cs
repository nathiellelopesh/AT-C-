
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AT_FallsTurism.Data;
using AT_FallsTurism.Models;
using Microsoft.EntityFrameworkCore;

namespace AT_FallsTurism.Pages.Reservas
{
    public class CreateReservationModel : PageModel
    {
        private readonly FallsTurismContext _context;

        public CreateReservationModel(FallsTurismContext context) {
            _context = context;
        }

        [BindProperty]
        public CreateReservationViewModel ReservaInput { get; set; } = new CreateReservationViewModel();
        public async Task<IActionResult> OnGetAsync() {
            // Popula os SelectLists para os dropdowns
            ReservaInput.Clientes = new SelectList(await _context.Clientes.ToListAsync(), "Id", "Nome");
            ReservaInput.PacotesTuristicos = new SelectList(await _context.PacotesTuristicos.ToListAsync(), "Id", "Titulo");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync() {
            ReservaInput.Clientes = new SelectList(await _context.Clientes.ToListAsync(), "Id", "Nome");
            ReservaInput.PacotesTuristicos = new SelectList(await _context.PacotesTuristicos.ToListAsync(), "Id", "Titulo");

            if (!ModelState.IsValid) {
                return Page();
            }

            //Reserva.DataReserva = DateTime.Now;

            var pacoteSelecionado = await _context.PacotesTuristicos
                                                .Include(p => p.Reservas)
                                                .FirstOrDefaultAsync(p => p.Id == ReservaInput.PacoteTuristicoId);

            if (pacoteSelecionado == null) {
                ModelState.AddModelError(string.Empty, "Pacote turístico selecionado não encontrado.");
                return Page();
            }

            if (pacoteSelecionado.DataInicio.Date <= DateTime.Today.Date) {
                ModelState.AddModelError(string.Empty, "Não é possível reservar pacotes com data de início passada ou no dia de hoje.");
                return Page();
            }

            var reservaExistente = await _context.Reservas
                                                 .AnyAsync(r => r.ClienteId == ReservaInput.ClienteId &&
                                                                r.PacoteTuristicoId == ReservaInput.PacoteTuristicoId &&
                                                                r.PacoteTuristico.DataInicio.Date == pacoteSelecionado.DataInicio.Date);

            if (reservaExistente) {
                ModelState.AddModelError(string.Empty, "Este cliente já possui uma reserva para este pacote na mesma data de início.");
                return Page();
            }


            // Cada pacote turístico tem um número máximo de clientes
            var currentReservationsCount = await _context.Reservas
                                                        .CountAsync(r => r.PacoteTuristicoId == ReservaInput.PacoteTuristicoId);

            if (currentReservationsCount >= pacoteSelecionado.CapacidadeMaxima) {
                ModelState.AddModelError(string.Empty, $"As vagas para o pacote '{pacoteSelecionado.Titulo}' estão esgotadas. Capacidade máxima de {pacoteSelecionado.CapacidadeMaxima} participantes atingida.");
                return Page();
            }

            // Se todas as validações passarem, criar e salvar a reserva
            var novaReserva = new Reserva {
                ClienteId = ReservaInput.ClienteId,
                PacoteTuristicoId = ReservaInput.PacoteTuristicoId,
                DataReserva = DateTime.Now
            };

            _context.Reservas.Add(novaReserva);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Reserva realizada com sucesso!";

            return RedirectToPage("/Index");
        }
    }
}
