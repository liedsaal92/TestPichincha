using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PichinchaTest.Entities
{
    public class cuenta
    {
        [Key]
        public int cuenta_id { get; set; }
        [Required]
        [Display(Name ="Número de cuenta")]
        [MaxLength(20, ErrorMessage = "Número cuenta no puede exceder de 25 carácteres")]
        public string numero_cuenta { get; set; }
        [Required]
        [Display(Name = "Tipo de cuenta")]
        [MaxLength(10, ErrorMessage = "Tipo de cuenta no puede exceder de 25 carácteres")]
        //[NotMapped]
        public string tipo_cuenta { get; set; }
        [Required]
        [Display(Name = "Saldo inicial de cuenta")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal saldo_inicial { get; set; }
        [Required]
        [Display(Name = "Estado de cuenta")]
        [MaxLength(10, ErrorMessage = "Estado no puede exceder de 25 carácteres")]
        public string estado { get; set; }
        [Required]
        public int cliente_id { get; set; }
    }
}
