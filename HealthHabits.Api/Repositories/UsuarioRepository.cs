using HealthHabits.Api.Data;
using HealthHabits.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthHabits.Api.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> ListarAsync()
        {
            return await _context.Usuarios
                .Include(u => u.Habitos)
                .ToListAsync();
        }

        public async Task<Usuario?> BuscarPorIdAsync(int id)
        {
            return await _context.Usuarios
                .Include(u => u.Habitos)
                .ThenInclude(h => h.Registros)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Usuario> CriarAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario?> AtualizarAsync(Usuario usuario)
        {
            var existente = await _context.Usuarios.FindAsync(usuario.Id);
            if (existente == null)
                return null;

            existente.Nome = usuario.Nome;
            existente.Email = usuario.Email;

            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> RemoverAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return false;

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
