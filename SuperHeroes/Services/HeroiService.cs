using NuGet.Protocol.Core.Types;
using SuperHeroes.Data;
using SuperHeroes.Data.DTOs;
using SuperHeroes.Interfaces;
using System.Net;
using static SuperHeroes.ExceptionMiddleware.GlobalExceptionMiddleware;

namespace SuperHeroes.Services
{
    public class HeroiService : IHeroiService
    {
        private IHeroiRepository _heroiRepository;
        public HeroiService(IHeroiRepository heroiRepository) 
        {
            _heroiRepository = heroiRepository;
        }

        public async Task<IEnumerable<Heroi>> GetAllHerois()
        {
            return await _heroiRepository.GetAllHerois();
        }

        public async Task<Heroi> GetHeroi(int id)
        {
            Heroi heroi = await _heroiRepository.GetByIdAsync(id);
            if (heroi == null)
                throw new CustomException(new ErrorResponse
                {
                    Message = "Nenhum herói com este Id foi encontrado.",
                    StatusCode = (int)HttpStatusCode.NotFound
                });
            return heroi;
        }

        public async Task<Heroi> AtualizarHeroiAsync(int id, PostHeroiDTO dto)
        {
            var heroi = await _heroiRepository.GetByIdAsync(id);
            if (heroi == null)
                throw new CustomException(new ErrorResponse
                {
                    Message = "Nenhum herói com este Id foi encontrado.",
                    StatusCode = (int)HttpStatusCode.NotFound
                });

            var poderes = await ValidarDadosHeroiAsync(dto);

            heroi.Nome = dto.Nome;
            heroi.NomeHeroi = dto.NomeHeroi;
            heroi.DataNascimento = dto.DataNascimento;
            heroi.Altura = dto.Altura;
            heroi.Peso = dto.Peso;
            heroi.Superpoderes = poderes;

            await _heroiRepository.AtualizarAsync();

            return heroi;
        }

        public async Task<Heroi> CriarHeroiAsync(PostHeroiDTO dto)
        {
            var poderes = await ValidarDadosHeroiAsync(dto);

            var novoHeroi = new Heroi
            {
                Nome = dto.Nome,
                NomeHeroi = dto.NomeHeroi,
                DataNascimento = dto.DataNascimento,
                Altura = dto.Altura,
                Peso = dto.Peso,
                Superpoderes = poderes
            };

            return await _heroiRepository.AdicionarAsync(novoHeroi);
        }

        public async Task ExcluirHeroiAsync(int id)
        {
            var heroi = await _heroiRepository.GetByIdAsync(id);
            if (heroi == null)
                throw new CustomException(new ErrorResponse
                {
                    Message = "Nenhum herói com este Id foi encontrado.",
                    StatusCode = (int)HttpStatusCode.NotFound
                });

            await _heroiRepository.RemoverAsync(heroi);
        }

        private async Task<List<SuperPoder>> ValidarDadosHeroiAsync(PostHeroiDTO dto, int? id = null)
        {
            if (dto.DataNascimento > DateTime.Today)
                throw new CustomException(new ErrorResponse
                {
                    Message = "Data de nascimento não pode ser do futuro.",
                    StatusCode = (int)HttpStatusCode.BadRequest
                });

            if (dto.SuperpoderesIds == null || !dto.SuperpoderesIds.Any())
                throw new CustomException(new ErrorResponse
                {
                    Message = "Um super-herói deve ter pelo menos um superpoder.",
                    StatusCode = (int)HttpStatusCode.BadRequest
                });

            bool nomeDuplicado = id.HasValue
                ? await _heroiRepository.NomeHeroiExisteAsync(dto.NomeHeroi, id.Value)
                : await _heroiRepository.NomeHeroiExisteAsync(dto.NomeHeroi);

            if (nomeDuplicado)
                throw new CustomException(new ErrorResponse
                {
                    Message = "Nome de herói já existe!",
                    StatusCode = (int)HttpStatusCode.BadRequest
                });

            var poderes = await _heroiRepository.BuscarSuperpoderesPorIdsAsync(dto.SuperpoderesIds);

            if (poderes.Count != dto.SuperpoderesIds.Count)
                throw new CustomException(new ErrorResponse
                {
                    Message = "Um ou mais superpoderes informados não existem.",
                    StatusCode = (int)HttpStatusCode.BadRequest
                });

            return poderes;
        }
    }
}
