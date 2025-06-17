namespace AT_FallsTurism.Models {
    public class Cliente {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public List<Reserva> Reservas { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}
