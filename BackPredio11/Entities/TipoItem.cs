namespace BackPredio11.Entities;

public class TipoItem
{
    public long TipoItemId { get; set; }
    public string ItemDescricao { get; set; }
    
    public ICollection<Item> Items { get; set; }
}