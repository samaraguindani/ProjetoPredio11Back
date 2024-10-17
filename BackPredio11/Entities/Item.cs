namespace BackPredio11.Entities;

public class Item
{
    public long ItemId { get; set; }
    public string ItemDescricao { get; set; }
    public int ItemPermitido { get; set; }
    
    public StatusItem StatusItem { get; set; }
    public long StatusItemId { get; set; }

    public TipoItem TipoItem { get; set; }
    public long TipoItemId { get; set; }

    public ICollection<Reserva> Reservas { get; set; }
    public ICollection<Retirada> Retiradas { get; set; }

}