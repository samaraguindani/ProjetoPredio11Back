using BackPredio11.Context;
using BackPredio11.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackPredio11.Repository;

public class ItemRepository
{
    private readonly AppDbContext _context;

    public ItemRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Item>> GetItens()
    {
        return await _context.Items.ToListAsync();
    }

    public async Task<ActionResult<Item>> GetItem(long id)
    {
        return await _context.Items.FindAsync(id);
    }
}