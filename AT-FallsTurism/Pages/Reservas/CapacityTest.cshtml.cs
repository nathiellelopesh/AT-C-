using AT_FallsTurism.Models;
using AT_FallsTurism.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AT_FallsTurism.Pages.Reservas {
    public class CapacityTestModel : PageModel {
        private static PacoteTuristico? _testPackage;

        public string StatusMessage { get; set; } = string.Empty;

        private Action<string> _consoleLogger;

        public CapacityTestModel() {
            _consoleLogger = LogService.LogToConsole;

            if (_testPackage == null) {
                _testPackage = new PacoteTuristico(
                    id: 100,
                    titulo: "Pacote Teste de Capacidade",
                    dataInicio: DateTime.Now,
                    capacidadeMaxima: 3, // Capacidade definida para teste
                    preco: 1000.00m
                );

                _testPackage.CapacityReached += (sender, e) => {
                    string message = $"ALERTA DE CAPACIDADE: Pacote '{e.PacoteTitulo}' (ID: {e.PacoteId}) atingiu/excedeu a capacidade máxima!";
                    message += $" Reservas Atuais: {e.ReservaAtual}, Capacidade Máxima: {e.MaximaCapacidade}.";

                    _consoleLogger?.Invoke(message);
                };

                StatusMessage = $"Pacote '{_testPackage.Titulo}' inicializado com capacidade de {_testPackage.CapacidadeMaxima}.";
            }
        }

        public void OnGet() {
            UpdatePageStatus();
        }

        public IActionResult OnPostAddReservation() {
            if (_testPackage == null) {
                StatusMessage = "Erro: Pacote de teste não inicializado.";
                return Page();
            }

            var newReservation = new Reserva {
                Id = _testPackage.CurrentReservationCount + 1,
                ClienteId = _testPackage.CurrentReservationCount + 100,
                PacoteTuristicoId = _testPackage.Id,
                DataReserva = DateTime.Now
            };

            _testPackage.AddReserva(newReservation);
            UpdatePageStatus();

            StatusMessage = $"Reserva {newReservation.Id} adicionada. Total de reservas: {_testPackage.CurrentReservationCount}.";

            return Page();
        }

        public IActionResult OnPostClearReservations() {
            if (_testPackage != null) {
                _testPackage.ClearReservas();
                StatusMessage = $"Reservas do pacote '{_testPackage.Titulo}' foram limpas.";
            }
            UpdatePageStatus();
            return Page();
        }

        private void UpdatePageStatus() {
            if (_testPackage != null) {
                StatusMessage = $"Pacote '{_testPackage.Titulo}' (Capacidade Máxima: {_testPackage.CapacidadeMaxima}). Reservas Atuais: {_testPackage.CurrentReservationCount}.";
                if (_testPackage.CurrentReservationCount >= _testPackage.CapacidadeMaxima) {
                    StatusMessage += " **CAPACIDADE ATINGIDA/EXCEDIDA!** Verifique o console do servidor para o alerta.";
                }
            }
        }
    }
}
