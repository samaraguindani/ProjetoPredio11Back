using BackPredio11.Entities;
using BackPredio11.Repository;
using BackPredio11.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackPredio11.Service;

//service vão as validações
public class PessoaService : IPessoaService
{
    private readonly PessoaRepository _repository;

    public PessoaService(PessoaRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Pessoa>> GetPessoas()
    {
        return await _repository.GetPessoas();
    }

    public async Task<ActionResult<Pessoa>> GetPessoa(long id)
    {
        return await _repository.GetPessoa(id);
    }
}