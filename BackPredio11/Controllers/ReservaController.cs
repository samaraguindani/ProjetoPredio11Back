using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackPredio11.Entities;
using BackPredio11.Service.Interfaces;

namespace BackPredio11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaService _reservaService;

        public ReservaController(IReservaService reservaService)
        {
            _reservaService = reservaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetReservas()
        {
            try
            {
                var reservas = await _reservaService.GetReservas();
                return Ok(reservas);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest("Request inválido");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reserva>> GetReserva(long id)
        {
            try
            {
                var reserva = await _reservaService.GetReserva(id);
                if (reserva == null)
                {
                    return NotFound("Não há reserva com esse ID");
                }

                return Ok(reserva);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest("Request inválido");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateReserva(Reserva reserva)
        {
            try
            {
                await _reservaService.CreateReserva(reserva);
                return CreatedAtRoute(nameof(GetReserva), new
                {
                    ReservaId = reserva.ReservaId
                }, reserva);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest("Request inválido");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReserva(long id, Reserva reserva)
        {
            try
            {
                if (reserva.ReservaId == id)
                {
                    await _reservaService.UpdateReserva(reserva);
                    return Ok($"Reserva de ID = {id} foi atualizado com sucesso");
                }
                return BadRequest("Dados inconsistentes");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest("Request inválido");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReserva(long id)
        {
            try
            {
                var reserva = await _reservaService.GetReserva(id);
                if (reserva == null)
                {
                    return NotFound($"Não foi possivel encontrar reserva com id = {id}");
                }

                await _reservaService.DeleteReserva(reserva);
            
                return Ok($"Cliente com id = {id} foi excluido com sucesso");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest("Request inválido");
            }
        }
    }
}
