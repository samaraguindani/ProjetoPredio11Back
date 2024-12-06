using BackPredio11.Entities;

public class Item
{
    public long ItemId { get; set; }
    public string ItemDescricao { get; set; }
    public int ItemPermitido { get; set; }
    public string TipoItem { get; set; }
    public int QuantidadeItem { get; set; }
    
    // Relacionamentos opcionais
    public ICollection<Reserva>? Reservas { get; set; } = new List<Reserva>();
    public ICollection<Retirada>? Retiradas { get; set; } = new List<Retirada>();
}