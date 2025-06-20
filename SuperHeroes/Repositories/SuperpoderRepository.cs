using Microsoft.EntityFrameworkCore;
using SuperHeroes.Data;
using SuperHeroes.Interfaces;

namespace SuperHeroes.Repositories
{
    public class SuperpoderRepository : ISuperpoderRepository
    {
        private readonly AppDbContext _context;

        public SuperpoderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<SuperPoder>> ListarTodosAsync()
        {
            return await _context.Superpoderes.ToListAsync();
        }
    }
}
