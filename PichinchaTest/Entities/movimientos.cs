using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PichinchaTest.Entities
{
    public class movimientos
    {
        [Key]
        public int movimiento_id { get; set; }
        [Required]
        [Display(Name = "Fecha de movimiento")]
        public DateTime fecha { get; set; }
        [Required]
        [Display(Name = "Tipo de movimiento")]
        [MaxLength(10, ErrorMessage = "Tipo de movimiento no puede exceder de 25 carácteres")]
        [EnumDataType(typeof(Helper.Enum.TipoMovimiento))]
        public string tipo_movimiento { get; set; }
        [Required]
        [Display(Name = "Valor de movimiento")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal valor { get; set; }
        [Required]
        [Display(Name = "Saldo")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal saldo { get; set; }
        [Required]
        public int cuenta_id { get; set; }
    }
    
}
