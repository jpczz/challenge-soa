using HealthHabits.Api.Data;
using HealthHabits.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthHabits.Api.Repositories
{
    public class HabitoRepository : IHabitoRepository
    {
        private readonly AppDbContext _context;

        public HabitoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Habito>> ListarPorUsuarioAsync(int usuarioId)
        {
            return await _context.Habitos
                .Where(h => h.UsuarioId == usuarioId)
                .Include(h => h.Registros)
                .ToListAsync();
        }

        public async Task<Habito?> BuscarPorIdAsync(int id)
        {
            return await _context.Habitos
                .Include(h => h.Registros)
                .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<Habito> CriarAsync(Habito habito)
        {
            _context.Habitos.Add(habito);
            await _context.SaveChangesAsync();
            return habito;
        }

        public async Task<Habito?> AtualizarAsync(Habito habito)
        {
            var existente = await _context.Habitos.FindAsync(habito.Id);
            if (existente == null)
                return null;

            existente.Tipo = habito.Tipo;
            existente.Unidade = habito.Unidade;
            existente.MetaDiaria = habito.MetaDiaria;

            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> RemoverAsync(int id)
        {
            var habito = await _context.Habitos.FindAsync(id);
            if (habito == null)
                return false;

            _context.Habitos.Remove(habito);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
