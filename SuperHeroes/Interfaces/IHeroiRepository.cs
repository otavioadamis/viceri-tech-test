using SuperHeroes.Data;

namespace SuperHeroes.Interfaces
{
    public interface IHeroiRepository
    {
        Task<IEnumerable<Heroi>> GetAllHerois();
        Task<Heroi?> GetByIdAsync(int id);
        Task<bool> NomeHeroiExisteAsync(string nomeHeroi, int idIgnorar);
        Task<bool> NomeHeroiExisteAsync(string nomeHeroi);
        Task<List<SuperPoder>> BuscarSuperpoderesPorIdsAsync(List<int> ids);
        Task AtualizarAsync();
        Task<Heroi> AdicionarAsync(Heroi heroi);
        Task RemoverAsync(Heroi heroi);
    }
}
