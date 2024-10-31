using BackPredio11.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackPredio11.Service.Interfaces;

public interface IReservaService
{
    Task<List<Reserva>> GetReservas();
    Task<Reserva> GetReserva(long id);
    Task CreateReserva(Reserva reserva);
    Task  UpdateReserva(Reserva reserva);
    Task  DeleteReserva(Reserva reserva);
}