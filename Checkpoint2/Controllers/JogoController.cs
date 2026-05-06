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

        /// <summary>
        /// Lista todos os jogos.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Jogo>>> GetJogos() => await _context.Jogos.ToListAsync();

        /// <summary>
        /// Busca um jogo por ID.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Jogo>> GetJogo(int id)
        {
            var jogo = await _context.Jogos.FindAsync(id);
            return jogo == null ? NotFound() : Ok(jogo);
        }

        /// <summary>
        /// Lista jogos disponíveis para aluguel.
        /// </summary>
        [HttpGet("disponiveis")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Jogo>>> GetJogosDisponiveis()
        {
            return await _context.Jogos.Where(j => j.Disponivel).ToListAsync();
        }

        /// <summary>
        /// Cadastra um novo jogo.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Jogo>> PostJogo(Jogo jogo)
        {
            // Regra: Se o jogo está disponível, ele NÃO pode ter um cliente vinculado!
            if (jogo.Disponivel)
            {
                jogo.ClienteId = null;
            }
            else if (jogo.ClienteId == 0 || jogo.ClienteId == null)
            {
                // Se o usuário marcar como indisponível (alugado), ele PRECISA passar um cliente
                return BadRequest("Para cadastrar um jogo como alugado, informe o ID do cliente.");
            }

            _context.Jogos.Add(jogo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetJogo), new { id = jogo.Id }, jogo);
        }

        /// <summary>
        /// Aluga um jogo vinculando-o a um cliente.
        /// </summary>
        [HttpPut("{id}/alugar/{clienteId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AlugarJogo(int id, int clienteId)
        {
            var jogo = await _context.Jogos.FindAsync(id);
            if (jogo == null) return NotFound("Jogo não encontrado.");
            if (!jogo.Disponivel) return BadRequest("Jogo já alugado.");

            var clienteExiste = await _context.Clientes.AnyAsync(c => c.Id == clienteId);
            if (!clienteExiste) return BadRequest("Cliente não existe.");

            jogo.Disponivel = false;
            jogo.ClienteId = clienteId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Atualiza dados de um jogo.
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutJogo(int id, Jogo jogo)
        {
            if (id != jogo.Id) return BadRequest();
            _context.Entry(jogo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Deleta um jogo do catálogo.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteJogo(int id)
        {
            var jogo = await _context.Jogos.FindAsync(id);
            if (jogo == null) return NotFound();
            _context.Jogos.Remove(jogo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}