using BackPredio11.Context;
using BackPredio11.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackPredio11.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PessoaController : ControllerBase
{
    private readonly AppDbContext _context;

    public PessoaController(AppDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pessoa>>> GetPessoas()
    {
        return await _context.Pessoas.ToListAsync();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Pessoa>> GetPessoa(long id)
    {
        var pessoa = await _context.Pessoas.FindAsync(id);

        if (pessoa == null)
        {
            return NotFound();
        }

        return pessoa;
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPessoa(long id, Pessoa pessoa)
    {
        if (id != pessoa.PessoaId)
        {
            return BadRequest();
        }

        _context.Entry(pessoa).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PessoaExists(id))
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
    
    [HttpPost]
    public async Task<ActionResult<Pessoa>> PostPessoa(Pessoa pessoa)
    {
        _context.Pessoas.Add(pessoa);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPessoa), new { id = pessoa.PessoaId }, pessoa);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePessoa(long id)
    {
        var pessoa = await _context.Pessoas.FindAsync(id);
        if (pessoa == null)
        {
            return NotFound();
        }

        _context.Pessoas.Remove(pessoa);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PessoaExists(long id)
    {
        return _context.Pessoas.Any(e => e.PessoaId == id);
    }
}