using System.ComponentModel.DataAnnotations;

namespace TestPichincha.Entities
{
    public class persona
    {
        public int persona_id { get; set; }
        [Required]
        [Display(Name = "Nombre de persona")]
        [MaxLength(50, ErrorMessage = "Nombre no puede exceder de 25 carácteres")]
        public string nombre { get; set; }
        [Required]
        [Display(Name = "Género")]
        [MaxLength(20, ErrorMessage = "Género no puede exceder de 25 carácteres")]
        public string genero { get; set; }
        [Required]
        [Display(Name = "Edad")]
        public int edad { get; set; }
        [Required]
        [Display(Name = "Identificación")]
        [MaxLength(20, ErrorMessage = "Identificación no puede exceder de 25 carácteres")]
        public string identificacion { get; set; }
        [Required]
        [Display(Name = "Dirección")]
        [MaxLength(250, ErrorMessage = "Dirección no puede exceder de 25 carácteres")]
        public string direccion { get; set; }
        [Required]
        [Display(Name = "Número de teléfono")]
        [MaxLength(15, ErrorMessage = "Teléfono no puede exceder de 25 carácteres")]
        public string telefono { get; set; }

    }
}
