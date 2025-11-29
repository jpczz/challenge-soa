using HealthHabits.Api.Models;

namespace HealthHabits.Api.Services
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> ListarAsync();
        Task<Usuario?> BuscarPorIdAsync(int id);
        Task<Usuario> CriarAsync(Usuario usuario);
        Task<Usuario?> AtualizarAsync(int id, Usuario usuario);
        Task<bool> RemoverAsync(int id);
    }
}
