using SuperHeroes.Data;

namespace SuperHeroes.Interfaces
{
    public interface ISuperpoderService
    {
        Task<List<SuperPoder>> ListarTodosAsync();
    }
}
