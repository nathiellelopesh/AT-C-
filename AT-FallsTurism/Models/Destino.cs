namespace AT_FallsTurism.Models {
    public class Destino {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Pais { get; set; }

        public List<PacoteTuristico> PacotesTuristicos { get; set; } = new List<PacoteTuristico>();

    }
}
