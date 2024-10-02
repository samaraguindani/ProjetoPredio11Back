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
    public async Task<ActionResult<IEnumerable<Bem>>> GetBens()
    {
        return await _context.Bem
            .Include(b => b.StatusBem)
            .Include(b => b.TipoBem)
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Bem>> GetBem(long id)
    {
        var bem = await _context.Bem
            .Include(b => b.StatusBem)
            .Include(b => b.TipoBem)
            .FirstOrDefaultAsync(b => b.BemId == id);

        if (bem == null)
        {
            return NotFound();
        }

        return bem;
    }

    [HttpPost]
    public async Task<ActionResult<Bem>> PostBem(Bem bem)
    {
        _context.Bem.Add(bem);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetBem), new { id = bem.BemId }, bem);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutBem(long id, Bem bem)
    {
        if (id != bem.BemId)
        {
            return BadRequest();
        }

        _context.Entry(bem).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BemExists(id))
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBem(long id)
    {
        var bem = await _context.Bem.FindAsync(id);
        if (bem == null)
        {
            return NotFound();
        }

        _context.Bem.Remove(bem);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool BemExists(long id)
    {
        return _context.Bem.Any(e => e.BemId == id);
    }

}