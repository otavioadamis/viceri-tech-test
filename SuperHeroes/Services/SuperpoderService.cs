using SuperHeroes.Data;
using SuperHeroes.Interfaces;

namespace SuperHeroes.Services
{
    public class SuperpoderService : ISuperpoderService
    {
        private readonly ISuperpoderRepository _repository;

        public SuperpoderService(ISuperpoderRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SuperPoder>> ListarTodosAsync()
        {
            return await _repository.ListarTodosAsync();
        }
    }
}
