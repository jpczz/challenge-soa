using HealthHabits.Api.Models;

namespace HealthHabits.Api.Repositories
{
    public interface IHabitoRepository
    {
        Task<List<Habito>> ListarPorUsuarioAsync(int usuarioId);
        Task<Habito?> BuscarPorIdAsync(int id);
        Task<Habito> CriarAsync(Habito habito);
        Task<Habito?> AtualizarAsync(Habito habito);
        Task<bool> RemoverAsync(int id);
    }
}
