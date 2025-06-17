
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AT_FallsTurism.Data;
using AT_FallsTurism.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace AT_FallsTurism.Pages.Clientes
{
    public class CreateClienteModel : PageModel {

        [BindProperty]
        public InputModel Input { get; set; }
        public Cliente Cliente { get; set; } = default!;

        private readonly FallsTurismContext _context;

        public CreateClienteModel(FallsTurismContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Cliente = new Cliente {
                Nome = Input.Nome,
                Email = Input.Email
            };

            _context.Clientes.Add(Cliente);

            await _context.SaveChangesAsync();

            return RedirectToPage("/Clientes/CreateCliente");
        }

        public class InputModel {
            [Required(ErrorMessage = "O nome é obrigatório.")]
            [MinLength(3, ErrorMessage = "O nome deve ter pelo menos 3 caracteres.")]
            public string Nome { get; set; }

            [Required(ErrorMessage = "Email é obrigatório.")]
            [StringLength(50, MinimumLength = 5, ErrorMessage = "O email deve ter entre 5 e 50 caracteres.")]
            public string Email { get; set; }
        }
    }
}
