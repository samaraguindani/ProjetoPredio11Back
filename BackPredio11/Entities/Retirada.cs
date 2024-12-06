namespace BackPredio11.Entities
{
    public class Retirada
    {
        public long RetiradaId { get; set; }
        public DateTime RetiradaData { get; set; }
        public DateTime DevolucaoData { get; set; }
        public DateTime LimiteData { get; set; }
        public int QuantidadeBem { get; set; }
        public string RetiradaDescricao { get; set; }
        public long PessoaId { get; set; }
        public long ItemId { get; set; }
        public Pessoa? Pessoa { get; set; }
        public Item? Item { get; set; }
    }
}