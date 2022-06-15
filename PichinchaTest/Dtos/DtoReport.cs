using System;

namespace PichinchaTest.Dtos
{
    public class DtoReport
    {
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public decimal SaldoInicial { get; set; }
        public string Estado { get; set; }
        public decimal Movimiento { get; set; }
        public decimal SaldoDisponible { get; set; }
    }
}
