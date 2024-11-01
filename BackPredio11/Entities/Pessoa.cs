﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackPredio11.Entities
{
    public class Pessoa
    {
        public long PessoaId { get; set; }
        public string PessoaNome { get; set; }
        public string PessoaIdUnivates { get; set; }
        public string PessoaTipo { get; set; }
        public string PessoaSenha { get; set; }

       public ICollection<Retirada> Retiradas { get; set; }
       public ICollection<Reserva> Reservas { get; set; }
    }
}
