using HealthHabits.Api.Data;
using HealthHabits.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthHabits.Api.Repositories
{
    public class RegistroHabitoRepository : IRegistroHabitoRepository
    {
        private readonly AppDbContext _context;

        public RegistroHabitoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<RegistroHabito>> ListarPorHabitoAsync(int habitoId)
        {
            return await _context.RegistrosHabito
                .Where(r => r.HabitoId == habitoId)
                .OrderByDescending(r => r.Data)
                .ToListAsync();
        }

        public async Task<RegistroHabito?> BuscarPorIdAsync(int id)
        {
            return await _context.RegistrosHabito
                .Include(r => r.Habito)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<RegistroHabito> CriarAsync(RegistroHabito registro)
        {
            _context.RegistrosHabito.Add(registro);
            await _context.SaveChangesAsync();
            return registro;
        }

        public async Task<bool> RemoverAsync(int id)
        {
            var registro = await _context.RegistrosHabito.FindAsync(id);
            if (registro == null)
                return false;

            _context.RegistrosHabito.Remove(registro);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> ObterSomaPorHabitoAsync(int habitoId)
        {
            return await _context.RegistrosHabito
                .Where(r => r.HabitoId == habitoId)
                .SumAsync(r => r.Valor);
        }

        public async Task<double> ObterMediaPorHabitoAsync(int habitoId)
        {
            var registros = await _context.RegistrosHabito
                .Where(r => r.HabitoId == habitoId)
                .ToListAsync();

            if (!registros.Any())
                return 0;

            return registros.Average(r => r.Valor);
        }
    }
}
