using Microsoft.AspNetCore.Mvc;
using BackPredio11.Context;
using BackPredio11.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackPredio11.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ItemController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItens()
        {
            return await _context.Items.Include(i => i.Reservas).Include(i => i.Retiradas).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(long id)
        {
            var item = await _context.Items.Include(i => i.Reservas).Include(i => i.Retiradas).FirstOrDefaultAsync(i => i.ItemId == id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Item>> CreateItem(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetItem), new { id = item.ItemId }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(long id, Item item)
        {
            if (id != item.ItemId)
                return BadRequest(new { message = "O ID do item não corresponde ao ID na URL." });

            // Verifica se o item existe antes de tentar atualizá-lo
            var existingItem = await _context.Items.AsNoTracking().FirstOrDefaultAsync(i => i.ItemId == id);
            if (existingItem == null)
                return NotFound(new { message = $"Item com ID = {id} não foi encontrado." });

            // Atualiza o item
            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return NoContent(); // Retorna 204 em caso de sucesso
            }
            catch (DbUpdateConcurrencyException)
            {
                // Verifica novamente se o item ainda existe
                if (!await _context.Items.AnyAsync(i => i.ItemId == id))
                    return NotFound(new { message = $"Item com ID = {id} não foi encontrado após tentativa de atualização." });

                throw; // Relança a exceção para ser tratada pelo middleware de erro
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(long id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null) return NotFound();

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}