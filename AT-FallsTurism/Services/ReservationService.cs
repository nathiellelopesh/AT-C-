using AT_FallsTurism.Data;
using AT_FallsTurism.Models;
using Microsoft.EntityFrameworkCore;

namespace AT_FallsTurism.Services {
    public interface IReservationService {
        public Task<List<Reserva>> GetAllAsync();
    }

    public class ReservationService : IReservationService {
        private readonly FallsTurismContext _context;

        public ReservationService(FallsTurismContext context) {
            _context = context;
        }

        public async Task<List<Reserva>> GetAllAsync() {
            return await _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.PacoteTuristico)
                .ToListAsync();
        }
    }
}
