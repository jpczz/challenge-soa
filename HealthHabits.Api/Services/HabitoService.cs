using HealthHabits.Api.Models;
using HealthHabits.Api.Repositories;

namespace HealthHabits.Api.Services
{
    public class HabitoService : IHabitoService
    {
        private readonly IHabitoRepository _habitoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public HabitoService(IHabitoRepository habitoRepository, IUsuarioRepository usuarioRepository)
        {
            _habitoRepository = habitoRepository;
            _usuarioRepository = usuarioRepository;
        }

        public Task<List<Habito>> ListarPorUsuarioAsync(int usuarioId)
        {
            return _habitoRepository.ListarPorUsuarioAsync(usuarioId);
        }

        public Task<Habito?> BuscarPorIdAsync(int id)
        {
            return _habitoRepository.BuscarPorIdAsync(id);
        }

        public async Task<Habito> CriarAsync(Habito habito)
        {
            await ValidarHabitoAsync(habito);
            return await _habitoRepository.CriarAsync(habito);
        }

        public async Task<Habito?> AtualizarAsync(int id, Habito habito)
        {
            if (id != habito.Id)
                throw new ArgumentException("ID do hábito na rota não confere com o corpo da requisição.");

            await ValidarHabitoAsync(habito);
            return await _habitoRepository.AtualizarAsync(habito);
        }

        public Task<bool> RemoverAsync(int id)
        {
            return _habitoRepository.RemoverAsync(id);
        }

        private async Task ValidarHabitoAsync(Habito habito)
        {
            if (habito.UsuarioId <= 0)
                throw new ArgumentException("Usuário inválido para o hábito.");

            var usuario = await _usuarioRepository.BuscarPorIdAsync(habito.UsuarioId);
            if (usuario == null)
                throw new ArgumentException("Usuário associado ao hábito não existe.");

            if (string.IsNullOrWhiteSpace(habito.Tipo))
                throw new ArgumentException("Tipo do hábito é obrigatório.");

            if (string.IsNullOrWhiteSpace(habito.Unidade))
                throw new ArgumentException("Unidade do hábito é obrigatória.");

            if (habito.MetaDiaria <= 0)
                throw new ArgumentException("Meta diária deve ser maior que zero.");
        }
    }
}
