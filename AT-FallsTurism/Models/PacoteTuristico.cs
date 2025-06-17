namespace AT_FallsTurism.Models {
    public class PacoteTuristico {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime DataInicio { get; set; }
        public int CapacidadeMaxima { get; set; }
        public decimal Preco { get; set; }
        public List<Destino> Destinos { get; set; }
        public List<Reserva> Reservas { get; set; }

        private List<Reserva> _reservasAtuais = new List<Reserva>();

        public event EventHandler<CapacityReachedEventArgs>? CapacityReached;

        public PacoteTuristico() { }

        public PacoteTuristico(int id, string titulo, DateTime dataInicio, int capacidadeMaxima, decimal preco) {
            Id = id;
            Titulo = titulo;
            DataInicio = dataInicio;
            CapacidadeMaxima = capacidadeMaxima;
            Preco = preco;
        }

        public void AddReserva(Reserva reserva) {
            if (reserva == null) {
                throw new ArgumentNullException(nameof(reserva), "A reserva não pode ser nula.");
            }

            _reservasAtuais.Add(reserva);
            Console.WriteLine($"Reserva {reserva.Id} adicionada ao pacote '{Titulo}'. Total de reservas: {_reservasAtuais.Count}. Capacidade Máxima: {CapacidadeMaxima}");

            if (_reservasAtuais.Count >= CapacidadeMaxima) {
                OnCapacityReached(new CapacityReachedEventArgs(Id, Titulo, _reservasAtuais.Count, CapacidadeMaxima));
            }
        }

        protected virtual void OnCapacityReached(CapacityReachedEventArgs e) {
            CapacityReached?.Invoke(this, e);
        }

        public int CurrentReservationCount => _reservasAtuais.Count;

        public void ClearReservas() {
            _reservasAtuais.Clear();
            Console.WriteLine($"Reservas do pacote '{Titulo}' limpas.");
        }
    }
}
