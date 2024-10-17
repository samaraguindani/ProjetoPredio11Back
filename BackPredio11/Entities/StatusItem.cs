namespace BackPredio11.Entities;

public class StatusItem
{
    public long StatusItemId { get; set; }
    public string ItemDescricao { get; set; }

    public ICollection<Item> Items { get; set; }
}