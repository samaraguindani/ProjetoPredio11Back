namespace BackPredio11.Entities;

public class Reserva
{
    public long ReservaId { get; set; }
    public DateTime ReservaData { get; set; }
    public DateTime ReservaDataValidade { get; set; }
    public int QuantidadeBem { get; set; }

    public Pessoa Pessoa { get; set; }
    public long PessoaId { get; set; }

    public Bem Bem { get; set; }
    public long BemId { get; set; }
}