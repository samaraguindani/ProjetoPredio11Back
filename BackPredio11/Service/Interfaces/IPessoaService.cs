using BackPredio11.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackPredio11.Service.Interfaces;

public interface IPessoaService
{
    Task<ActionResult<IEnumerable<Pessoa>>> GetPessoas();
    Task<ActionResult<Pessoa>> GetPessoa(long id);
}