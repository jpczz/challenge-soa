using HealthHabits.Api.Models;
using HealthHabits.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthHabits.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class RegistrosHabitoController : ControllerBase
    {
        private readonly IRegistroHabitoService _registroService;

        public RegistrosHabitoController(IRegistroHabitoService registroService)
        {
            _registroService = registroService;
        }

        // GET api/habitos/{habitoId}/registros
        [HttpGet("habitos/{habitoId:int}/registros")]
        public async Task<IActionResult> ListarPorHabito(int habitoId)
        {
            var registros = await _registroService.ListarPorHabitoAsync(habitoId);
            return Ok(registros);
        }

        // POST api/habitos/{habitoId}/registros
        [HttpPost("habitos/{habitoId:int}/registros")]
        public async Task<IActionResult> Post(int habitoId, [FromBody] RegistroHabito registro)
        {
            try
            {
                registro.HabitoId = habitoId;

                var criado = await _registroService.CriarAsync(registro);
                return CreatedAtAction(nameof(GetById), new { id = criado.Id }, criado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { mensagem = "Erro interno ao criar registro de hábito." });
            }
        }

        // GET api/registros/{id}
        [HttpGet("registros/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var registro = await _registroService.BuscarPorIdAsync(id);
            if (registro == null)
                return NotFound(new { mensagem = "Registro não encontrado." });

            return Ok(registro);
        }

        // DELETE api/registros/{id}
        [HttpDelete("registros/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removido = await _registroService.RemoverAsync(id);
            if (!removido)
                return NotFound(new { mensagem = "Registro não encontrado." });

            return NoContent();
        }
    }
}
