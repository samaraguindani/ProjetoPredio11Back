using BackPredio11.Entities;

public class Reserva
{
    public long ReservaId { get; set; }
    public DateTime ReservaData { get; set; }
    public DateTime ReservaDataValidade { get; set; }
    public int QuantidadeBem { get; set; }
    public long ItemId { get; set; } // Relacionamento via ID
    public long PessoaId { get; set; } // Relacionamento via ID
    public Item? Item { get; set; } // Torne opcional
    public Pessoa? Pessoa { get; set; } // Torne opcional
}