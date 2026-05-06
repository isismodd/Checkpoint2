using Checkpoint2.Data;
using Checkpoint2.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JogoController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public JogoController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jogo>>> GetJogos()
        {
            return await _context.Jogos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Jogo>> GetJogo(int id)
        {
            var jogo = await _context.Jogos.FindAsync(id);
            if (jogo == null) return NotFound();
            return jogo;
        }

        [HttpPut("{id}/alugar")]
        public async Task<IActionResult> AlugarJogo(int id)
        {
            var jogo = await _context.Jogos.FindAsync(id);
            if (jogo == null || !jogo.Disponivel) return BadRequest("Jogo indisponível ou não encontrado.");

            jogo.Disponivel = false;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}