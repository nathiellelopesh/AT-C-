namespace AT_FallsTurism.Models {
    public class CapacityReachedEventArgs : EventArgs {
        public int PacoteId { get; }
        public string PacoteTitulo { get; }
        public int ReservaAtual { get; }
        public int MaximaCapacidade { get; }

        public CapacityReachedEventArgs(int pacoteId, string pacoteTitulo, int reservaAtual, int maximaCapacidade) {
            PacoteId = pacoteId;
            PacoteTitulo = pacoteTitulo;
            ReservaAtual = reservaAtual;
            MaximaCapacidade = maximaCapacidade;
        }
    }
}
