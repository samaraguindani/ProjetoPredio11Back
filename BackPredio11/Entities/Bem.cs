namespace BackPredio11.Entities;

public class Bem
{
    public long BemId { get; set; }
    public string BemDescricao { get; set; }
    public int BemPermitido { get; set; }
    
    public StatusBem StatusBem { get; set; }
    public long StatusBemId { get; set; }

    public TipoBem TipoBem { get; set; }
    public long TipoBemId { get; set; }

    public ICollection<ItensReserva> ItensReserva { get; set; }
    public ICollection<ItensRetirada> ItensRetirada { get; set; }

}