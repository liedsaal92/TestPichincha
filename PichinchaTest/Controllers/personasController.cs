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
    public class personasController : ControllerBase
    {
        private readonly TestPichinchaContext _context;

        public personasController(TestPichinchaContext context)
        {
            _context = context;
        }

        // GET: api/persona
        [HttpGet]
        public async Task<ActionResult<IEnumerable<persona>>> Getpersona()
        {
            return await _context.persona.ToListAsync();
        }

        // GET: api/persona/5
        [HttpGet("{id}")]
        public async Task<ActionResult<persona>> Getpersona(int id)
        {
            var persona = await _context.persona.FindAsync(id);

            if (persona == null)
            {
                return NotFound();
            }

            return persona;
        }

        // PUT: api/persona/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putpersona(int id, persona persona)
        {
            if (id != persona.persona_id)
            {
                return BadRequest();
            }

            _context.Entry(persona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!personaExists(id))
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

        // POST: api/persona
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<persona>> Postpersona(persona persona)
        {
            _context.persona.Add(persona);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getpersona", new { id = persona.persona_id }, persona);
        }

        // DELETE: api/persona/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletepersona(int id)
        {
            var persona = await _context.persona.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            _context.persona.Remove(persona);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool personaExists(int id)
        {
            return _context.persona.Any(e => e.persona_id == id);
        }
    }
}
