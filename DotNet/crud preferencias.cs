using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SistemaRecomendacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreferenciaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PreferenciaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Preferencia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Preferencia>>> Get()
        {
            return await _context.Preferencias.ToListAsync();
        }

        // GET: api/Preferencia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Preferencia>> Get(int id)
        {
            var preferencia = await _context.Preferencias.FindAsync(id);

            if (preferencia == null)
            {
                return NotFound();
            }

            return preferencia;
        }

        // POST: api/Preferencia
        [HttpPost]
        public async Task<ActionResult<Preferencia>> Post(Preferencia novaPreferencia)
        {
            _context.Preferencias.Add(novaPreferencia);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = novaPreferencia.Id }, novaPreferencia);
        }

        // PUT: api/Preferencia/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Preferencia preferenciaAtualizada)
        {
            if (id != preferenciaAtualizada.Id)
            {
                return BadRequest();
            }

            _context.Entry(preferenciaAtualizada).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Preferencia/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var preferencia = await _context.Preferencias.FindAsync(id);
            if (preferencia == null)
            {
                return NotFound();
            }

            _context.Preferencias.Remove(preferencia);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}