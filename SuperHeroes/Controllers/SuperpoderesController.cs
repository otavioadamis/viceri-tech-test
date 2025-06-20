using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroes.Data;

namespace SuperHeroes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperpoderesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SuperpoderesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/SuperPoderes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SuperPoder>>> GetSuperPoderes()
        {
            return await _context.Superpoderes.ToListAsync();
        }
    }
}
