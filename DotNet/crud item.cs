using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SistemaRecomendacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemRecomendadoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ItemRecomendadoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ItemRecomendado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemRecomendado>>> Get()
        {
            return await _context.ItemRecomendados.ToListAsync();
        }

        // GET: api/ItemRecomendado/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemRecomendado>> Get(int id)
        {
            var itemRecomendado = await _context.ItemRecomendados.FindAsync(id);

            if (itemRecomendado == null)
            {
                return NotFound();
            }

            return itemRecomendado;
        }

        // POST: api/ItemRecomendado
        [HttpPost]
        public async Task<ActionResult<ItemRecomendado>> Post(ItemRecomendado novoItemRecomendado)
        {
            _context.ItemRecomendados.Add(novoItemRecomendado);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = novoItemRecomendado.Id }, novoItemRecomendado);
        }

        // PUT: api/ItemRecomendado/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ItemRecomendado itemRecomendadoAtualizado)
        {
            if (id != itemRecomendadoAtualizado.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemRecomendadoAtualizado).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/ItemRecomendado/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var itemRecomendado = await _context.ItemRecomendados.FindAsync(id);
            if (itemRecomendado == null)
            {
                return NotFound();
            }

            _context.ItemRecomendados.Remove(itemRecomendado);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}