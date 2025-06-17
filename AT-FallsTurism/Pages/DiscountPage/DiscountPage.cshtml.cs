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
                ErrorMessage = "Preço inválido.";
                MemoryLogs = LogService.GetMemoryLogs().ToList();
                return;
            }

            try {
                DiscountedPrice = _calculateDiscount(OriginalPrice);
                ErrorMessage = null; // Limpa qualquer mensagem de erro anterior

                string logMessage = $"Operação de Cálculo de Desconto: Preço Original={OriginalPrice:C}, Preço Descontado={DiscountedPrice:C}";
                
                _logOperations?.Invoke(logMessage);

            } catch (ArgumentOutOfRangeException ex) {
                ErrorMessage = "O preço deve ser um número não negativo.";
                DiscountedPrice = 0.00m; 
                _logOperations?.Invoke($"Erro no Cálculo de Desconto: {ex.Message} para Preço Original={OriginalPrice}");
            } catch (Exception ex) {
                ErrorMessage = "Ocorreu um erro ao calcular o desconto.";
                DiscountedPrice = 0.00m;
                _logOperations?.Invoke($"Erro Inesperado no Cálculo de Desconto: {ex.Message} para Preço Original={OriginalPrice}");
            }
            MemoryLogs = LogService.GetMemoryLogs().ToList();
        }

        //limpar os logs em memória
        public IActionResult OnPostClearLogs() {
            LogService.ClearMemoryLogs();
            ErrorMessage = "Logs em memória limpos!";
            MemoryLogs = LogService.GetMemoryLogs().ToList(); // Deve ser uma lista vazia agora
            return Page();
        }
    }
}
