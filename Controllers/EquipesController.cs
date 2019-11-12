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

        // GET: api/Equipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipe>>> GetEquipes()
        {
            return await _context.Equipes.ToListAsync();
        }

        // GET: api/Equipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Equipe>> GetEquipe(long id)
        {
            var innerJoin = from e in _context.Equipes where e.id == id
                            join p1 in _context.Personagens on e.personagem1.id equals p1.id into p1x from px1 in p1x.DefaultIfEmpty()
                            join c1 in _context.Classes on px1.classe.id equals c1.id into c1x from cx1 in c1x.DefaultIfEmpty()
                            join p2 in _context.Personagens on e.personagem2.id equals p2.id into p2x from px2 in p2x.DefaultIfEmpty()
                            join c2 in _context.Classes on px2.classe.id equals c2.id into c2x from cx2 in c2x.DefaultIfEmpty()
                            join p3 in _context.Personagens on e.personagem3.id equals p3.id into p3x from px3 in p3x.DefaultIfEmpty()
                            join c3 in _context.Classes on px3.classe.id equals c3.id into c3x from cx3 in c3x.DefaultIfEmpty()
                            join p4 in _context.Personagens on e.personagem4.id equals p4.id into p4x from px4 in p4x.DefaultIfEmpty()
                            join c4 in _context.Classes on px4.classe.id equals c4.id into c4x from cx4 in c4x.DefaultIfEmpty()
                            join p5 in _context.Personagens on e.personagem5.id equals p5.id into p5x from px5 in p5x.DefaultIfEmpty()
                            join c5 in _context.Classes on px5.classe.id equals c5.id into c5x from cx5 in c5x.DefaultIfEmpty()
                            join p6 in _context.Personagens on e.personagem6.id equals p6.id into p6x from px6 in p6x.DefaultIfEmpty()
                            join c6 in _context.Classes on px6.classe.id equals c6.id into c6x from cx6 in c6x.DefaultIfEmpty()
                            join m1 in _context.Mascotes on e.mascote1.id equals m1.id into m1x from mx1 in m1x.DefaultIfEmpty()
                            join m2 in _context.Mascotes on e.mascote2.id equals m2.id into m2x from mx2 in m2x.DefaultIfEmpty()
                            select new Equipe
                            {
                                id = e.id,
                                personagem1 = px1 == null ? null : new Personagem { id = px1.id, nome = px1.nome, classe = cx1 == null ? null : (new Classe { id = cx1.id, nome = cx1.nome }) },
                                personagem2 = px2 == null ? null : new Personagem { id = px2.id, nome = px2.nome, classe = cx2 == null ? null : (new Classe { id = cx2.id, nome = cx2.nome }) },
                                personagem3 = px3 == null ? null : new Personagem { id = px3.id, nome = px3.nome, classe = cx3 == null ? null : (new Classe { id = cx3.id, nome = cx3.nome }) },
                                personagem4 = px4 == null ? null : new Personagem { id = px4.id, nome = px4.nome, classe = cx4 == null ? null : (new Classe { id = cx4.id, nome = cx4.nome }) },
                                personagem5 = px5 == null ? null : new Personagem { id = px5.id, nome = px5.nome, classe = cx5 == null ? null : (new Classe { id = cx5.id, nome = cx5.nome }) },
                                personagem6 = px6 == null ? null : new Personagem { id = px6.id, nome = px6.nome, classe = cx6 == null ? null : (new Classe { id = cx6.id, nome = cx6.nome }) },
                                mascote1 = mx1 == null ? null : new Mascote { id = mx1.id, nome = mx1.nome },
                                mascote2 = mx2 == null ? null : new Mascote { id = mx2.id, nome = mx2.nome }
                            };
            
            var equipe = await innerJoin.FirstOrDefaultAsync();

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
