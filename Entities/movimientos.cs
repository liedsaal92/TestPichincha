using System.ComponentModel.DataAnnotations;

namespace TestPichincha.Entities
{
    public class movimientos
    {
        public int movimiento_id { get; set; }
        [Required]
        [Display(Name = "Fecha de movimiento")]
        public DateTime fecha { get; set; }
        [Required]
        [Display(Name = "Tipo de movimiento")]
        [MaxLength(10, ErrorMessage = "Tipo de movimiento no puede exceder de 25 carácteres")]
        public string tipo_movimiento { get; set; }
        [Required]
        [Display(Name = "Valor de movimiento")]
        public decimal valor { get; set; }
        [Required]
        [Display(Name = "Saldo")]
        public decimal saldo { get; set; }
    }
}
