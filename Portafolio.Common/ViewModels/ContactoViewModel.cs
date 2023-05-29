using System.ComponentModel.DataAnnotations;

namespace Portafolio.Common.ViewModels
{
    public class ContactoViewModel
    {
        [Display(Name = "Nombre Completo")]
        [MaxLength(75, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string Nombre { get; set; }

        [Display(Name = "Correo Electronico")]
        [MaxLength(60, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Mensaje")]
        [MaxLength(500, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string Mensaje { get; set; }
    }
}
