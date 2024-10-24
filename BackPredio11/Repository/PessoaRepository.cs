using BackPredio11.Context;
using BackPredio11.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackPredio11.Repository;

//select e buscas de banco 
public class PessoaRepository
{
    private readonly AppDbContext _context;

    public PessoaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Pessoa>> GetPessoas()
    {
        return await _context.Pessoas.ToListAsync();
         
    }

    public async Task<ActionResult<Pessoa>> GetPessoa(long id)
    {
        return await _context.Pessoas.FindAsync(id);
    }
}