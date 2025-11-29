using HealthHabits.Api.Models;

namespace HealthHabits.Api.Repositories
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> ListarAsync();
        Task<Usuario?> BuscarPorIdAsync(int id);
        Task<Usuario> CriarAsync(Usuario usuario);
        Task<Usuario?> AtualizarAsync(Usuario usuario);
        Task<bool> RemoverAsync(int id);
    }
}
