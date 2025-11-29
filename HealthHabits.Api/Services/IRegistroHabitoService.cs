using HealthHabits.Api.Models;

namespace HealthHabits.Api.Services
{
    public interface IRegistroHabitoService
    {
        Task<List<RegistroHabito>> ListarPorHabitoAsync(int habitoId);
        Task<RegistroHabito?> BuscarPorIdAsync(int id);
        Task<RegistroHabito> CriarAsync(RegistroHabito registro);
        Task<bool> RemoverAsync(int id);

        Task<int> ObterSomaPorHabitoAsync(int habitoId);
        Task<double> ObterMediaPorHabitoAsync(int habitoId);
    }
}
