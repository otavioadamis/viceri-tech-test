using Microsoft.EntityFrameworkCore;
using SuperHeroes.Data;
using SuperHeroes.Interfaces;

namespace SuperHeroes.Repositories
{
    public class HeroiRepository : IHeroiRepository
    {
        private readonly AppDbContext _context;

        public HeroiRepository(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<IEnumerable<Heroi>> GetAllHerois()
        {
            return await _context.Herois
            .Include(h => h.Superpoderes)
            .ToListAsync();
        }

        public async Task<Heroi?> GetByIdAsync(int id)
        {
            return await _context.Herois
                .Include(h => h.Superpoderes)
                .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<bool> NomeHeroiExisteAsync(string nomeHeroi, int idIgnorar)
        {
            return await _context.Herois
                .AnyAsync(h => h.NomeHeroi == nomeHeroi && h.Id != idIgnorar);
        }

        public async Task<bool> NomeHeroiExisteAsync(string nomeHeroi)
        {
            return await _context.Herois.AnyAsync(h => h.NomeHeroi == nomeHeroi);
        }

        public async Task<List<SuperPoder>> BuscarSuperpoderesPorIdsAsync(List<int> ids)
        {
            return await _context.Superpoderes
                .Where(sp => ids.Contains(sp.Id))
                .ToListAsync();
        }

        public async Task AtualizarAsync()
        {
            await _context.SaveChangesAsync();

        }

        public async Task<Heroi> AdicionarAsync(Heroi heroi)
        {
            _context.Herois.Add(heroi);
            await _context.SaveChangesAsync();
            return heroi;
        }

        public async Task RemoverAsync(Heroi heroi)
        {
            _context.Herois.Remove(heroi);
            await _context.SaveChangesAsync();
        }
    }
}
