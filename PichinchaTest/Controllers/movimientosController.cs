using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PichinchaTest.Entities;
using PichinchaTest.Helper;
using PichinchaTest.Services;

namespace PichinchaTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class movimientosController : ControllerBase
    {
        private readonly TestPichinchaContext _context;

        public movimientosController(TestPichinchaContext context)
        {
            _context = context;
        }

        // GET: api/movimientos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<movimientos>>> Getmovimientos()
        {
            return await _context.movimientos.ToListAsync();
        }

        // GET: api/movimientos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<movimientos>> Getmovimientos(int id)
        {
            var movimientos = await _context.movimientos.FindAsync(id);

            if (movimientos == null)
            {
                return NotFound();
            }

            return movimientos;
        }

        // PUT: api/movimientos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putmovimientos(int id, movimientos movimientos)
        {
            if (id != movimientos.movimiento_id)
            {
                return BadRequest();
            }

            _context.Entry(movimientos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!movimientosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/movimientos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<movimientos>> Postmovimientos(movimientos movimientos)
        {
            if (movimientos.valor<=0)
                return Content("El valor debe ser mayor a cero (0)");
            
            //se valida saldo de cuenta
            cuenta cuenta = await _context.cuenta.FindAsync(movimientos.cuenta_id);
            if (cuenta.saldo_inicial==0 && movimientos.tipo_movimiento.Equals(TipoMovimiento.Debito.ToString()))
                return Content("Saldo no disponible.");
            
            List<movimientos> lista = _context.movimientos.ToList();
            //
            if (movimientos.tipo_movimiento.Equals(TipoMovimiento.Debito.ToString()))
            {
                movimientos.valor = - Math.Abs(movimientos.valor);
                cuenta.saldo_inicial = cuenta.saldo_inicial - movimientos.valor;
                movimientos.saldo = cuenta.saldo_inicial;
            }
            else
            {
                movimientos.valor = Math.Abs(movimientos.valor);
                cuenta.saldo_inicial = cuenta.saldo_inicial + movimientos.valor;
                movimientos.saldo = cuenta.saldo_inicial;
            }

            decimal cupoDiarioUsado = 0;
            foreach (var item in lista)
            {
                if (item.fecha==movimientos.fecha)
                    cupoDiarioUsado = cupoDiarioUsado + item.valor;
            }
           
            if (cupoDiarioUsado + movimientos.valor >= Constantes.CupoDiario && movimientos.tipo_movimiento.Equals(TipoMovimiento.Debito.ToString()))
            {
                return Content("Cupo diario Excedido, actualmente solo dispone de: $"+ (Constantes.CupoDiario- cupoDiarioUsado));
            }
            else {
                //Modifica valores en cuenta
                _context.Entry(cuenta);

                _context.movimientos.Add(movimientos);
                await _context.SaveChangesAsync();

                return CreatedAtAction("Getmovimientos", new { id = movimientos.movimiento_id }, movimientos);
            }
        }

        // DELETE: api/movimientos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletemovimientos(int id)
        {
            var movimientos = await _context.movimientos.FindAsync(id);
            if (movimientos == null)
            {
                return NotFound();
            }

            _context.movimientos.Remove(movimientos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool movimientosExists(int id)
        {
            return _context.movimientos.Any(e => e.movimiento_id == id);
        }
    }
}
