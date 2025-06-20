using SuperHeroes.Data;

namespace SuperHeroes.Interfaces
{
    public interface ISuperpoderRepository
    {
        Task<List<SuperPoder>> ListarTodosAsync();
    }
}
