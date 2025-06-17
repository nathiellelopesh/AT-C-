using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AT_FallsTurism.Models {
    public class CreateReservationViewModel {
        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "O campo Cliente é obrigatório.")]
        public int ClienteId { get; set; }

        [Display(Name = "Pacote Turístico")]
        [Required(ErrorMessage = "O campo Pacote Turístico é obrigatório.")]
        public int PacoteTuristicoId { get; set; }

        

        public SelectList? Clientes { get; set; }
        public SelectList? PacotesTuristicos { get; set; }
    }
}
