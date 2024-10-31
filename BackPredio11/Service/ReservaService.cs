using BackPredio11.Entities;
using BackPredio11.Repository;
using BackPredio11.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackPredio11.Service;

public class ReservaService : IReservaService
{
    private readonly ReservaRepository _repository;

    public ReservaService(ReservaRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Reserva>> GetReservas()
    {
        throw new NotImplementedException();
    }

    public async Task<Reserva> GetReserva(long id)
    {
        throw new NotImplementedException();
    }

    public async Task CreateReserva(Reserva reserva)
    {
        var reservaBancoDados = new Reserva
        {
            ReservaData = reserva.ReservaData,
            ReservaDataValidade = reserva.ReservaDataValidade,
            QuantidadeBem = reserva.QuantidadeBem,
        };
        
        await _repository.CreateReserva(reservaBancoDados);
    }

    public async Task UpdateReserva(Reserva reserva)
    {
        var reservaBancoDados = await _repository.GetReserva(reserva.ReservaId);

        if (reservaBancoDados == null)
        {
            throw new ArgumentNullException();
        }

        reservaBancoDados.ReservaData = reserva.ReservaData;
        reservaBancoDados.ReservaDataValidade = reserva.ReservaDataValidade;
        reservaBancoDados.QuantidadeBem = reserva.QuantidadeBem;

        await _repository.UpdateReserva(reservaBancoDados);
    }

    public async Task  DeleteReserva(Reserva reserva)
    {
        await _repository.DeleteReserva(reserva.ReservaId);
    }
}