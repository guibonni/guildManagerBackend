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
    public class EquipesController : ControllerBase
    {
        private readonly GuildManagerContext _context;

        public EquipesController(GuildManagerContext context)
        {
            _context = context;
        }

        // GET: api/Equipes?resumido=false
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Object>>> GetEquipes([FromQuery] bool resumido)
        {
            if (resumido) {
                var query = from e in _context.Equipes
                            select new
                            {
                                id = e.id,
                                personagem1 = e.personagem1.nome,
                                personagem2 = e.personagem2.nome,
                                personagem3 = e.personagem3.nome,
                                personagem4 = e.personagem4.nome,
                                mascote1 = e.mascote1.nome
                            };
                
                return await query.ToListAsync();
            } else {
                var query = from e in _context.Equipes
                            select new Equipe
                            {
                                id = e.id,
                                personagem1 = new Personagem 
                                { 
                                    id = e.personagem1.id, 
                                    nome = e.personagem1.nome, 
                                    classe = e.personagem1.classe
                                },
                                personagem2 = new Personagem 
                                { 
                                    id = e.personagem2.id, 
                                    nome = e.personagem2.nome, 
                                    classe = e.personagem2.classe
                                },
                                personagem3 = new Personagem 
                                { 
                                    id = e.personagem3.id, 
                                    nome = e.personagem3.nome, 
                                    classe = e.personagem3.classe
                                },
                                personagem4 = new Personagem 
                                { 
                                    id = e.personagem4.id, 
                                    nome = e.personagem4.nome, 
                                    classe = e.personagem4.classe
                                },
                                personagem5 = new Personagem 
                                { 
                                    id = e.personagem5.id, 
                                    nome = e.personagem5.nome, 
                                    classe = e.personagem5.classe
                                },
                                personagem6 = new Personagem 
                                { 
                                    id = e.personagem6.id, 
                                    nome = e.personagem6.nome, 
                                    classe = e.personagem6.classe
                                },
                                mascote1 = e.mascote1,
                                mascote2 = e.mascote2
                            };
                
                return await query.ToListAsync();
            }
        }

        // GET: api/Equipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Equipe>> GetEquipe(long id)
        {
            var query = from e in _context.Equipes where e.id == id
                        select new Equipe
                        {
                            id = e.id,
                            personagem1 = new Personagem 
                            { 
                                id = e.personagem1.id, 
                                nome = e.personagem1.nome, 
                                classe = e.personagem1.classe
                            },
                            personagem2 = new Personagem 
                            { 
                                id = e.personagem2.id, 
                                nome = e.personagem2.nome, 
                                classe = e.personagem2.classe
                            },
                            personagem3 = new Personagem 
                            { 
                                id = e.personagem3.id, 
                                nome = e.personagem3.nome, 
                                classe = e.personagem3.classe
                            },
                            personagem4 = new Personagem 
                            { 
                                id = e.personagem4.id, 
                                nome = e.personagem4.nome, 
                                classe = e.personagem4.classe
                            },
                            personagem5 = new Personagem 
                            { 
                                id = e.personagem5.id, 
                                nome = e.personagem5.nome, 
                                classe = e.personagem5.classe
                            },
                            personagem6 = new Personagem 
                            { 
                                id = e.personagem6.id, 
                                nome = e.personagem6.nome, 
                                classe = e.personagem6.classe
                            },
                            mascote1 = e.mascote1,
                            mascote2 = e.mascote2
                        };
            
            var equipe = await query.FirstOrDefaultAsync();

            if (equipe == null) {
                return NotFound();
            }

            return equipe;
        }

        // PUT: api/Equipes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipe(long id, Equipe equipe)
        {
            if (id != equipe.id)
            {
                return BadRequest();
            }

            _context.Entry(equipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipeExists(id))
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

        // POST: api/Equipes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Equipe>> PostEquipe(Equipe equipe)
        {
            _context.Equipes.Add(equipe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipe", new { id = equipe.id }, equipe);
        }

        // DELETE: api/Equipes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Equipe>> DeleteEquipe(long id)
        {
            var equipe = await _context.Equipes.FindAsync(id);
            if (equipe == null)
            {
                return NotFound();
            }

            _context.Equipes.Remove(equipe);
            await _context.SaveChangesAsync();

            return equipe;
        }

        private bool EquipeExists(long id)
        {
            return _context.Equipes.Any(e => e.id == id);
        }
    }
}
