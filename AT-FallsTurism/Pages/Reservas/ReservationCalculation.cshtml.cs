using AT_FallsTurism.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AT_FallsTurism.Pages.Reservas
{
    public class ReservationCalculationModel : PageModel
    {
        [BindProperty]
        public int NumberOfNights { get; set; }

        [BindProperty]
        public decimal DailyRate { get; set; }

        public decimal TotalReservationValue { get; set; }

        public string? Message { get; set; }

        public List<string> MemoryLogs { get; set; } = new List<string>();

        private Func<int, decimal, decimal> _calculateTotal;

        private Action<string> _logOperations;

        public ReservationCalculationModel() {
            _calculateTotal = (nights, rate) => nights * rate;

            _logOperations = LogService.LogToConsole;
            _logOperations += LogService.LogToFile;
            _logOperations += LogService.LogToMemory;
        }

        public void OnGet() {

            MemoryLogs = LogService.GetMemoryLogs().ToList();
        }

        public IActionResult OnPost() {
            if (NumberOfNights <= 0 || DailyRate <= 0) {
                Message = "Por favor, digite um número de diárias e um valor da diária positivos.";
                MemoryLogs = LogService.GetMemoryLogs().ToList();
                return Page();
            }

            TotalReservationValue = _calculateTotal(NumberOfNights, DailyRate);

            Message = "Cálculo realizado com sucesso!";

            string logMessage = $"Operação de Cálculo de Reserva: Diárias={NumberOfNights}, Valor Diária={DailyRate:C}, Valor Total={TotalReservationValue:C}";
            _logOperations?.Invoke(logMessage);

            MemoryLogs = LogService.GetMemoryLogs().ToList();

            return Page();
        }

        public IActionResult OnPostClearLogs() {
            LogService.ClearMemoryLogs();
            Message = "Logs em memória limpos!";
            MemoryLogs = LogService.GetMemoryLogs().ToList();
            return Page();
        }
    }
}
