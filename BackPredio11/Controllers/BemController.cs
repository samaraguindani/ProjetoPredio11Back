using BackPredio11.Context;
using BackPredio11.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackPredio11.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BemController : ControllerBase
{
private readonly AppDbContext _context;

    public BemController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Item>>> GetItens()
    {
        try
        {
            var itens = await _context.Items.ToListAsync();
            return Ok(itens);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, "Ocorreu um erro ao buscar os itens.");        
        }

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Item>> GetItem(long id)
    {
        try
        {
            var item = await _context.Items
                .Include(b => b.StatusItem)
                .Include(b => b.TipoItem)
                .FirstOrDefaultAsync(b => b.ItemId == id);
    
            if (item == null)
            {
                return NotFound();
            }
    
            return Ok(item);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, "Ocorreu um erro ao buscar o item.");        

        }
        
    }

    [HttpPost]
    public async Task<ActionResult<Item>> PostItem(Item item)
    {
        try
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            var novoItem = CreatedAtAction(nameof(GetItem), new { id = item.ItemId }, item);
            return Ok(novoItem);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, "Ocorreu um erro ao criar o item.");        
        }
        
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutItem(long id, Item item)
    {
        if (id != item.ItemId)
        {
            return BadRequest();
        }

        _context.Entry(item).State = EntityState.Modified;

        try
        {
            var atualizaItem = await _context.SaveChangesAsync();
            return Ok(atualizaItem);
        }
        catch (DbUpdateConcurrencyException)
        {
            var BemExists = _context.Items.Any(e => e.ItemId == id);

            if (!BemExists)
            {
                return NotFound();
            }
        }
        return StatusCode(500, "Ocorreu um erro ao atualizar o item.");        
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteItem(long id)
    {
        try
        {
            var bem = await _context.Items.FindAsync(id);
            if (bem == null)
            {
                return NotFound();
            }

            _context.Items.Remove(bem);
            var itemDeletado = await _context.SaveChangesAsync();
            return Ok(itemDeletado);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, "Ocorreu um erro ao deletar o item.");        
        }
    }
}