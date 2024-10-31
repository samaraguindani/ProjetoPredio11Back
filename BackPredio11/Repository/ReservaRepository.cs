using BackPredio11.Context;
using BackPredio11.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackPredio11.Repository;

public class ReservaRepository
{
    private readonly AppDbContext _context;

    public ReservaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Reserva>> GetReservas()
    {
        return await _context.Reservas.ToListAsync();
    }

    public async Task<Reserva> GetReserva(long id)
    {
        return await _context.Reservas.FindAsync(id);
    }
    
    public async Task CreateReserva(Reserva reserva)
    {
       _context.Reservas.Add(reserva);
       await _context.SaveChangesAsync();
    }

    public async Task UpdateReserva(Reserva reserva)
    {
        _context.Entry(reserva).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteReserva(long id)
    {
        var reserva = await _context.Reservas.FindAsync(id);
        if (reserva != null)
        {
            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();
        }
    }

}