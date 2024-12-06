using BackPredio11.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackPredio11.Entities;

namespace BackPredio11.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RetiradaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RetiradaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Retirada
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var retiradas = await _context.Retiradas
                .Include(r => r.Pessoa)
                .Include(r => r.Item)
                .ToListAsync();
            return Ok(retiradas);
        }

        // GET: api/Retirada/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var retirada = await _context.Retiradas
                .Include(r => r.Pessoa)
                .Include(r => r.Item)
                .FirstOrDefaultAsync(r => r.RetiradaId == id);

            if (retirada == null)
                return NotFound();

            return Ok(retirada);
        }

        // POST: api/Retirada
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Retirada retirada)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Verifica e vincula a pessoa
            var pessoaExistente = await _context.Pessoas.FindAsync(retirada.Pessoa.PessoaId);
            if (pessoaExistente == null)
            {
                // Adiciona nova pessoa se não existir
                _context.Pessoas.Add(retirada.Pessoa);
            }
            else
            {
                // Usa a pessoa existente
                retirada.Pessoa = pessoaExistente;
            }

            // Trata o campo "item" como uma string (possível identificação do item ou descrição)
            // var itemExistente = await _context.Items.FirstOrDefaultAsync(i => i.ItemDescricao == retirada.Item);
            // if (itemExistente == null)
            //     return BadRequest("Item não encontrado.");
            //
            // retirada.Item = itemExistente;

            // Adiciona a nova retirada ao contexto
            _context.Retiradas.Add(retirada);

            // Salva as alterações
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = retirada.RetiradaId }, retirada);
        }


        // PUT: api/Retirada/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] Retirada retirada)
        {
            if (id != retirada.RetiradaId)
                return BadRequest("ID da Retirada não corresponde.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingRetirada = await _context.Retiradas.FindAsync(id);
            if (existingRetirada == null)
                return NotFound();

            // Atualiza os dados da retirada
            existingRetirada.RetiradaData = retirada.RetiradaData;
            existingRetirada.DevolucaoData = retirada.DevolucaoData;
            existingRetirada.LimiteData = retirada.LimiteData;
            existingRetirada.QuantidadeBem = retirada.QuantidadeBem;
            existingRetirada.RetiradaDescricao = retirada.RetiradaDescricao;
            existingRetirada.Pessoa.PessoaId = retirada.Pessoa.PessoaId;
            existingRetirada.Item.ItemId = retirada.Item.ItemId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Retirada/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var retirada = await _context.Retiradas.FindAsync(id);
            if (retirada == null)
                return NotFound();

            _context.Retiradas.Remove(retirada);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
