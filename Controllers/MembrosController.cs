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
    public class MembrosController : ControllerBase
    {
        private readonly GuildManagerContext _context;

        public MembrosController(GuildManagerContext context)
        {
            _context = context;
        }

        // GET: api/Membros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Membro>>> GetMembros()
        {
            var query = from m in _context.Membros
                        join c in _context.Cargos on m.cargo.id equals c.id
                        select new Membro
                        {
                            id = m.id,
                            nome = m.nome,
                            cargo = new Cargo { id = c.id, nome = c.nome }
                        };

            return await query.ToListAsync();
        }

        // GET: api/Membros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Membro>> GetMembro(long id)
        {
            var query = from m in _context.Membros where m.id == id
                        join c in _context.Cargos on m.cargo.id equals c.id
                        select new Membro
                        {
                            id = m.id,
                            nome = m.nome,
                            cargo = new Cargo { id = c.id, nome = c.nome }
                        };

            var membro = await query.FirstOrDefaultAsync();

            if (membro == null)
            {
                return NotFound();
            }

            return membro;
        }

        // PUT: api/Membros/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMembro(long id, Membro membro)
        {
            if (id != membro.id)
            {
                return BadRequest();
            }

            _context.Entry(membro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MembroExists(id))
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

        // POST: api/Membros
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Membro>> PostMembro(Membro membro)
        {
            _context.Membros.Add(membro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMembro", new { id = membro.id }, membro);
        }

        // DELETE: api/Membros/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Membro>> DeleteMembro(long id)
        {
            var membro = await _context.Membros.FindAsync(id);
            if (membro == null)
            {
                return NotFound();
            }

            _context.Membros.Remove(membro);
            await _context.SaveChangesAsync();

            return membro;
        }

        private bool MembroExists(long id)
        {
            return _context.Membros.Any(e => e.id == id);
        }
    }
}
