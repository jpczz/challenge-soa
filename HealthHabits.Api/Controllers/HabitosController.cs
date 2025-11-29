using HealthHabits.Api.Models;
using HealthHabits.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthHabits.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class HabitosController : ControllerBase
    {
        private readonly IHabitoService _habitoService;
        private readonly IRegistroHabitoService _registroService;

        public HabitosController(
            IHabitoService habitoService,
            IRegistroHabitoService registroService)
        {
            _habitoService = habitoService;
            _registroService = registroService;
        }

        // GET api/usuarios/{usuarioId}/habitos
        [HttpGet("usuarios/{usuarioId:int}/habitos")]
        public async Task<IActionResult> ListarPorUsuario(int usuarioId)
        {
            var habitos = await _habitoService.ListarPorUsuarioAsync(usuarioId);
            return Ok(habitos);
        }

        // GET api/habitos/{id}
        [HttpGet("habitos/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var habito = await _habitoService.BuscarPorIdAsync(id);
            if (habito == null)
                return NotFound(new { mensagem = "Hábito não encontrado." });

            return Ok(habito);
        }

        // POST api/habitos
        [HttpPost("habitos")]
        public async Task<IActionResult> Post([FromBody] Habito habito)
        {
            try
            {
                var criado = await _habitoService.CriarAsync(habito);
                return CreatedAtAction(nameof(GetById), new { id = criado.Id }, criado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { mensagem = "Erro interno ao criar hábito." });
            }
        }

        // PUT api/habitos/{id}
        [HttpPut("habitos/{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] Habito habito)
        {
            try
            {
                var atualizado = await _habitoService.AtualizarAsync(id, habito);
                if (atualizado == null)
                    return NotFound(new { mensagem = "Hábito não encontrado." });

                return Ok(atualizado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { mensagem = "Erro interno ao atualizar hábito." });
            }
        }

        // DELETE api/habitos/{id}
        [HttpDelete("habitos/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removido = await _habitoService.RemoverAsync(id);
            if (!removido)
                return NotFound(new { mensagem = "Hábito não encontrado." });

            return NoContent();
        }

        // GET api/habitos/{id}/estatisticas
        [HttpGet("habitos/{id:int}/estatisticas")]
        public async Task<IActionResult> Estatisticas(int id)
        {
            var soma = await _registroService.ObterSomaPorHabitoAsync(id);
            var media = await _registroService.ObterMediaPorHabitoAsync(id);

            return Ok(new
            {
                habitoId = id,
                soma,
                media
            });
        }
    }
}
