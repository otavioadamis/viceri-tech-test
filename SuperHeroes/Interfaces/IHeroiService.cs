using SuperHeroes.Data;
using SuperHeroes.Data.DTOs;

namespace SuperHeroes.Interfaces
{
    public interface IHeroiService
    {
        Task<IEnumerable<Heroi>> GetAllHerois();
        Task<Heroi> GetHeroi(int id);
        Task<Heroi> AtualizarHeroiAsync(int id, PostHeroiDTO dto);
        Task<Heroi> CriarHeroiAsync(PostHeroiDTO dto);
        Task ExcluirHeroiAsync(int id);
    }
}
