using HealthHabits.Api.Models;
using HealthHabits.Api.Repositories;

namespace HealthHabits.Api.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Task<List<Usuario>> ListarAsync()
        {
            return _usuarioRepository.ListarAsync();
        }

        public Task<Usuario?> BuscarPorIdAsync(int id)
        {
            return _usuarioRepository.BuscarPorIdAsync(id);
        }

        public async Task<Usuario> CriarAsync(Usuario usuario)
        {
            ValidarUsuario(usuario);
            return await _usuarioRepository.CriarAsync(usuario);
        }

        public async Task<Usuario?> AtualizarAsync(int id, Usuario usuario)
        {
            if (id != usuario.Id)
                throw new ArgumentException("ID do usuário na rota não confere com o corpo da requisição.");

            ValidarUsuario(usuario);
            return await _usuarioRepository.AtualizarAsync(usuario);
        }

        public Task<bool> RemoverAsync(int id)
        {
            return _usuarioRepository.RemoverAsync(id);
        }

        private void ValidarUsuario(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Nome))
                throw new ArgumentException("Nome do usuário é obrigatório.");

            if (string.IsNullOrWhiteSpace(usuario.Email))
                throw new ArgumentException("Email do usuário é obrigatório.");

            if (!usuario.Email.Contains("@"))
                throw new ArgumentException("Email inválido.");
        }
    }
}
