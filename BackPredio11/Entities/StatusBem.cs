namespace BackPredio11.Entities;

public class StatusBem
{
    public long StatusBemId { get; set; }
    public string StatusNome { get; set; }

    public ICollection<Bem> Bem { get; set; }
}