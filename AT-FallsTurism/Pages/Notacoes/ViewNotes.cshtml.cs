using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static AT_FallsTurism.Pages.Clientes.CreateClienteModel;

namespace AT_FallsTurism.Pages.Notacoes
{
    public class ViewNotesModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }
        public string Caminho { get; set; }
        public List<string?> Arquivos { get; set; } = new();
        public string ConteudoDoArquivoLido { get; set; }

        string diretorio = "wwwroot/files";

        public void OnGet(string? nomeDoArquivoParaVer = null) {
            if (Directory.Exists(diretorio)) {
                Arquivos = Directory.GetFiles(diretorio).
                    Select(Path.GetFileName).ToList();
            }
            if (!string.IsNullOrEmpty(nomeDoArquivoParaVer)) {
                string caminhoCompletoDoArquivo = Path.Combine(diretorio, nomeDoArquivoParaVer);
                if (System.IO.File.Exists(caminhoCompletoDoArquivo)) {
                    ConteudoDoArquivoLido = System.IO.File.ReadAllText(caminhoCompletoDoArquivo);
                }
            }
        }

        public void OnPost() {
            if (!ModelState.IsValid) {
                OnGet();
                return;
            }

            string arquivo = $"nota_{DateTime.Now:yyyyMMddHHmmss}.txt";
            
            string caminho = diretorio + "/" + arquivo;
            System.IO.File.WriteAllText(caminho, Input.Conteudo);
            Caminho = "/files/" + arquivo;
        }
    }

    public class InputModel {
        [Required]
        public string Conteudo { get; set; }
    }
}
