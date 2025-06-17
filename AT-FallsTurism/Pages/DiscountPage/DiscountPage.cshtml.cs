using AT_FallsTurism.Delegates;
using AT_FallsTurism.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static AT_FallsTurism.Delegates.DiscountDelegates;

namespace AT_FallsTurism.Pages.DiscountPage
{
    public class DiscountPageModel : PageModel
    {
        [BindProperty]
        public decimal OriginalPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public string? ErrorMessage { get; set; }


        public List<string> MemoryLogs { get; set; } = new List<string>();

        private CalculateDiscountDelegate _calculateDiscount;

        private Action<string> _logOperations;

        public DiscountPageModel() {
            _calculateDiscount = DiscountCalculator.ApplyDiscount;

            _logOperations = LogService.LogToConsole;  
            _logOperations += LogService.LogToFile;    
            _logOperations += LogService.LogToMemory;  
        }

        public void OnGet() {
            MemoryLogs = LogService.GetMemoryLogs().ToList();
        }

        public void OnPost() {
            if (!ModelState.IsValid) {
                ErrorMessage = "Pre�o inv�lido.";
                MemoryLogs = LogService.GetMemoryLogs().ToList();
                return;
            }

            try {
                DiscountedPrice = _calculateDiscount(OriginalPrice);
                ErrorMessage = null; // Limpa qualquer mensagem de erro anterior

                string logMessage = $"Opera��o de C�lculo de Desconto: Pre�o Original={OriginalPrice:C}, Pre�o Descontado={DiscountedPrice:C}";
                
                _logOperations?.Invoke(logMessage);

            } catch (ArgumentOutOfRangeException ex) {
                ErrorMessage = "O pre�o deve ser um n�mero n�o negativo.";
                DiscountedPrice = 0.00m; 
                _logOperations?.Invoke($"Erro no C�lculo de Desconto: {ex.Message} para Pre�o Original={OriginalPrice}");
            } catch (Exception ex) {
                ErrorMessage = "Ocorreu um erro ao calcular o desconto.";
                DiscountedPrice = 0.00m;
                _logOperations?.Invoke($"Erro Inesperado no C�lculo de Desconto: {ex.Message} para Pre�o Original={OriginalPrice}");
            }
            MemoryLogs = LogService.GetMemoryLogs().ToList();
        }

        //limpar os logs em mem�ria
        public IActionResult OnPostClearLogs() {
            LogService.ClearMemoryLogs();
            ErrorMessage = "Logs em mem�ria limpos!";
            MemoryLogs = LogService.GetMemoryLogs().ToList(); // Deve ser uma lista vazia agora
            return Page();
        }
    }
}
