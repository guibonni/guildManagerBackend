using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GCGuildManager.Models;

namespace GCGuildManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonagensController : ControllerBase
    {
        private readonly GuildManagerContext _context;

        public PersonagensController(GuildManagerContext context)
        {
            _context = context;
        }

        // GET: api/Personagens
        [HttpGet]
        public async Task<List<Personagem>> GetPersonagens()
        {
            var innerJoin = from p in _context.Personagens
                            select new Personagem
                            {
                                id = p.id,
                                nome = p.nome,
                                classe = p.classe
                            };
            
            return await innerJoin.ToListAsync();
        }

        // GET: api/Personagens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Personagem>> GetPersonagem(long id)
        {
            var innerJoin = from p in _context.Personagens where p.id == id
                            select new Personagem
                            {
                                id = p.id,
                                nome = p.nome,
                                classe = p.classe
                            };
            
            var personagem = await innerJoin.FirstOrDefaultAsync();

            if (personagem == null) {
                return NotFound();
            }

            return personagem;
        }

        // PUT: api/Personagens/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonagem(long id, Personagem personagem)
        {
            if (id != personagem.id)
            {
                return BadRequest();
            }

            _context.Entry(personagem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonagemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Personagens
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Personagem>> PostPersonagem(Personagem personagem)
        {
            _context.Personagens.Add(personagem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonagem", new { id = personagem.id }, personagem);
        }

        // DELETE: api/Personagens/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Personagem>> DeletePersonagem(long id)
        {
            var personagem = await _context.Personagens.FindAsync(id);
            if (personagem == null)
            {
                return NotFound();
            }

            _context.Personagens.Remove(personagem);
            await _context.SaveChangesAsync();

            return personagem;
        }

        private bool PersonagemExists(long id)
        {
            return _context.Personagens.Any(e => e.id == id);
        }
    }
}
