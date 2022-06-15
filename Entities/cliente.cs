using System.ComponentModel.DataAnnotations;

namespace TestPichincha.Entities
{
    public class cliente
    {
        
        public int cliente_id { get; set; }
        [Required]
        [Display(Name = "Contraseña")]
        [MaxLength(25,ErrorMessage ="Contraseña no puede exceder de 25 carácteres")]
        public string constrasena { get; set; }
        [Required]
        [Display(Name = "Estao de cliente")]
        [MaxLength(20, ErrorMessage = "Estado no puede exceder de 25 carácteres")]
        public string estado { get; set; }
        [Required]
        public int persona_id { get; set; }
    }
}
