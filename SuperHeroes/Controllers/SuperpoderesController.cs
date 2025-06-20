using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroes.Data;
using SuperHeroes.Interfaces;
using SuperHeroes.Services;

namespace SuperHeroes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperpoderesController : ControllerBase
    {
        private readonly ISuperpoderService _superpoderService;

        public SuperpoderesController(ISuperpoderService superpoderService)
        {
            _superpoderService = superpoderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SuperPoder>>> GetSuperPoderes()
        {
            var poderes = await _superpoderService.ListarTodosAsync();
            return Ok(poderes);
        }
    }
}
