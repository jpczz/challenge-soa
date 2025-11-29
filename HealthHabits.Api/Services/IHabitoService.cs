using HealthHabits.Api.Models;

namespace HealthHabits.Api.Services
{
    public interface IHabitoService
    {
        Task<List<Habito>> ListarPorUsuarioAsync(int usuarioId);
        Task<Habito?> BuscarPorIdAsync(int id);
        Task<Habito> CriarAsync(Habito habito);
        Task<Habito?> AtualizarAsync(int id, Habito habito);
        Task<bool> RemoverAsync(int id);
    }
}
