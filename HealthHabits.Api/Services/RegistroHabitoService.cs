using HealthHabits.Api.Models;
using HealthHabits.Api.Repositories;

namespace HealthHabits.Api.Services
{
    public class RegistroHabitoService : IRegistroHabitoService
    {
        private readonly IRegistroHabitoRepository _registroRepository;
        private readonly IHabitoRepository _habitoRepository;

        public RegistroHabitoService(
            IRegistroHabitoRepository registroRepository,
            IHabitoRepository habitoRepository)
        {
            _registroRepository = registroRepository;
            _habitoRepository = habitoRepository;
        }

        public Task<List<RegistroHabito>> ListarPorHabitoAsync(int habitoId)
        {
            return _registroRepository.ListarPorHabitoAsync(habitoId);
        }

        public Task<RegistroHabito?> BuscarPorIdAsync(int id)
        {
            return _registroRepository.BuscarPorIdAsync(id);
        }

        public async Task<RegistroHabito> CriarAsync(RegistroHabito registro)
        {
            await ValidarRegistroAsync(registro);
            return await _registroRepository.CriarAsync(registro);
        }

        public Task<bool> RemoverAsync(int id)
        {
            return _registroRepository.RemoverAsync(id);
        }

        public Task<int> ObterSomaPorHabitoAsync(int habitoId)
        {
            return _registroRepository.ObterSomaPorHabitoAsync(habitoId);
        }

        public Task<double> ObterMediaPorHabitoAsync(int habitoId)
        {
            return _registroRepository.ObterMediaPorHabitoAsync(habitoId);
        }

        private async Task ValidarRegistroAsync(RegistroHabito registro)
        {
            if (registro.HabitoId <= 0)
                throw new ArgumentException("Hábito inválido para o registro.");

            var habito = await _habitoRepository.BuscarPorIdAsync(registro.HabitoId);
            if (habito == null)
                throw new ArgumentException("Hábito associado ao registro não existe.");

            if (registro.Valor <= 0)
                throw new ArgumentException("Valor do registro deve ser maior que zero.");

            if (registro.Data == default)
                registro.Data = DateTime.UtcNow;
        }
    }
}
