using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroes.Data;
using SuperHeroes.Data.DTOs;
using SuperHeroes.Interfaces;

namespace SuperHeroes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroisController : ControllerBase
    {
        private readonly IHeroiService _heroiService;

        public HeroisController(IHeroiService heroiService)
        {
            _heroiService = heroiService;
        }

        // GET: api/Herois
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Heroi>>> GetHerois()
        {
            var allHeroes = await _heroiService.GetAllHerois();
            return Ok(allHeroes);
        }

        // GET: api/Herois/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Heroi>> GetHeroi(int id)
        {
            var heroi = await _heroiService.GetHeroi(id);
            return Ok(heroi);
        }

        // PUT: api/Herois/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHeroi(int id, PostHeroiDTO heroi)
        {
            var atualizado = await _heroiService.AtualizarHeroiAsync(id, heroi);
            return Ok(atualizado);
        }

        // POST: api/Herois
        [HttpPost]
        public async Task<ActionResult<Heroi>> PostHeroi(PostHeroiDTO heroi)
        {
            var novoHeroi = await _heroiService.CriarHeroiAsync(heroi);
            return CreatedAtAction(nameof(GetHeroi), new { id = novoHeroi.Id }, novoHeroi);
        }

        // DELETE: api/Herois/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHeroi(int id)
        {
            await _heroiService.ExcluirHeroiAsync(id);

            return Ok(new { mensagem = "Herói excluído com sucesso." });
        }
    }
}
