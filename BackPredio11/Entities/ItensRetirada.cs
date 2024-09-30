namespace BackPredio11.Entities;

public class ItensRetirada
{
    public int QuantidadeBem { get; set; }

    public Retirada Retirada { get; set; }
    public long RetiradaId { get; set; }

    public Bem Bem { get; set; }
    public long BemId { get; set; }
}