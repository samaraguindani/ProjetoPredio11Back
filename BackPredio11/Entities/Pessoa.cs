using BackPredio11.Entities;

public class Pessoa
{
    public long PessoaId { get; set; }
    public string PessoaNome { get; set; }
    public string PessoaIdUnivates { get; set; }
    public string PessoaTipo { get; set; }
    public string PessoaSenha { get; set; }
    public string PessoaUsername { get; set; }

    // Relacionamentos opcionais
    public ICollection<Reserva>? Reservas { get; set; } = new List<Reserva>();
    public ICollection<Retirada>? Retiradas { get; set; } = new List<Retirada>();
}