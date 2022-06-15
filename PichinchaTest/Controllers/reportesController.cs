using Microsoft.AspNetCore.Mvc;
using PichinchaTest.Dtos;
using PichinchaTest.Entities;
using PichinchaTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PichinchaTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class reportesController : ControllerBase
    {
        private readonly TestPichinchaContext _context;

        public reportesController(TestPichinchaContext context)
        {
            _context = context;
        }

        // GET: api/fecha/
        [HttpGet("{idCliente}/{fechaIni}/{fechaFin}")]
        public async Task<ActionResult<List<DtoReport>>> Getreport(int idCliente,DateTime fechaIni, DateTime fechaFin)
        {
            List<cuenta> listaCuentas= _context.cuenta.Where(c => c.cliente_id == idCliente).ToList();
            cliente cliente= _context.cliente.Find(idCliente);
            persona persona= _context.persona.Find(cliente.persona_id);
            
            List<DtoReport> reports = new List<DtoReport>();
            
            foreach (var item in listaCuentas)
            {
                List<movimientos> listaMovimientos = new List<movimientos>();
                listaMovimientos.AddRange(_context.movimientos.Where(c=>c.cuenta_id==item.cuenta_id && (c.fecha>=fechaIni && c.fecha<=fechaFin)).ToList());
                foreach (var item2 in listaMovimientos)
                {
                    DtoReport report = new DtoReport();
                    report.Cliente = persona.nombre;
                    report.Fecha = item2.fecha;
                    report.Numero = item.numero_cuenta;
                    report.Tipo = item.tipo_cuenta;
                    report.SaldoInicial = item.saldo_inicial;
                    report.Estado = item.estado;
                    report.Movimiento = item2.valor;
                    report.SaldoDisponible = item2.saldo;
                    reports.Add(report);
                }
            }
            return reports;
        }
    }
}
