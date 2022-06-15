using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PichinchaTest.Entities;
using PichinchaTest.Services;

namespace PichinchaTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class cuentasController : ControllerBase
    {
        private readonly TestPichinchaContext _context;

        public cuentasController(TestPichinchaContext context)
        {
            _context = context;
        }

        // GET: api/cuenta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cuenta>>> Getcuenta()
        {
            return await _context.cuenta.ToListAsync();
        }

        // GET: api/cuenta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<cuenta>> Getcuenta(int id)
        {
            var cuenta = await _context.cuenta.FindAsync(id);

            if (cuenta == null)
            {
                return NotFound();
            }

            return cuenta;
        }

        // PUT: api/cuenta/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcuenta(int id, cuenta cuenta)
        {
            if (id != cuenta.cuenta_id)
            {
                return BadRequest();
            }

            _context.Entry(cuenta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cuentaExists(id))
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

        // POST: api/cuenta
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<cuenta>> Postcuenta(cuenta cuenta)
        {
            _context.cuenta.Add(cuenta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcuenta", new { id = cuenta.cuenta_id }, cuenta);
        }

        // DELETE: api/cuenta/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecuenta(int id)
        {
            var cuenta = await _context.cuenta.FindAsync(id);
            if (cuenta == null)
            {
                return NotFound();
            }

            _context.cuenta.Remove(cuenta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool cuentaExists(int id)
        {
            return _context.cuenta.Any(e => e.cuenta_id == id);
        }
    }
}
