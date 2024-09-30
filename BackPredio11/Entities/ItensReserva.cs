namespace BackPredio11.Entities;

public class ItensReserva
{
    public string QuantidadeBem { get; set; }

    public Bem Bem { get; set; }
    public long BemId { get; set; }

    public Reserva Reserva { get; set; }
    public long ReservaId { get; set; }
}