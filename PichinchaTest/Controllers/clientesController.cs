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
    public class clientesController : ControllerBase
    {
        private readonly TestPichinchaContext _context;

        public clientesController(TestPichinchaContext context)
        {
            _context = context;
        }

        // GET: api/cliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cliente>>> Getcliente()
        {
            return await _context.cliente.ToListAsync();
        }

        // GET: api/cliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<cliente>> Getcliente(int id)
        {
            var cliente = await _context.cliente.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // PUT: api/cliente/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcliente(int id, cliente cliente)
        {
            if (id != cliente.cliente_id)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!clienteExists(id))
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

        // POST: api/cliente
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<cliente>> Postcliente(cliente cliente)
        {
            _context.cliente.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcliente", new { id = cliente.cliente_id }, cliente);
        }

        // DELETE: api/cliente/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecliente(int id)
        {
            var cliente = await _context.cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.cliente.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool clienteExists(int id)
        {
            return _context.cliente.Any(e => e.cliente_id == id);
        }
    }
}
