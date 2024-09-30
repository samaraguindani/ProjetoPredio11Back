namespace BackPredio11.Entities
{
    public class MotivoRetirada
    {
        public long MotivoRetiradaId { get; set; }
        public string MotivoDescricao { get; set; }

        public ICollection<Retirada> Retiradas { get; set; }
    }
}
