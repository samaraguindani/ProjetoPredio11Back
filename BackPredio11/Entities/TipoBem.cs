namespace BackPredio11.Entities;

public class TipoBem
{
    public long TipoBemId { get; set; }
    public string TipoNome { get; set; }
    
    public ICollection<Bem> Bem { get; set; }
}