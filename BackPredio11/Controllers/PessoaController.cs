using BackPredio11.Entities;
using BackPredio11.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackPredio11.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PessoaController : ControllerBase
{
    private readonly IPessoaService _pessoaService;

    public PessoaController(IPessoaService pessoaService)
    {
        _pessoaService = pessoaService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pessoa>>> GetPessoas()
    {
        try
        {
            var pessoas = await _pessoaService.GetPessoas();
            return Ok(pessoas);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro ao buscar pessoas: {e.Message}");
            Console.WriteLine(e.StackTrace); 
            return StatusCode(500, "Ocorreu um erro ao encontrar pessoas");        
        }
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Pessoa>> GetPessoa(long id)
    {
        try
        {
            var pessoa = await _pessoaService.GetPessoa(id);

            if (pessoa == null)
            {
                return NotFound();
            }

            return Ok(pessoa);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, "Ocorreu um erro ao encontrar pessoa");
        }
        
    }
}