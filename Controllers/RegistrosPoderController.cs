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
    public class RegistrosPoderController : ControllerBase
    {
        private readonly GuildManagerContext _context;

        public RegistrosPoderController(GuildManagerContext context)
        {
            _context = context;
        }

        // GET: api/RegistrosPoder?resumido=false
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Object>>> GetRegistrosPoder([FromQuery] bool resumido)
        {
            if (resumido) {
                var query = from r in _context.RegistrosPoder orderby r.data descending
                            select new
                            {
                                id = r.id,
                                data = r.data.ToShortDateString(),
                                membro = r.membro.nome,
                                poder = r.poder
                            };

                return await query.ToListAsync();
            } else {
                var query = from r in _context.RegistrosPoder
                            select new RegistroPoder
                            {
                                id = r.id,
                                data = r.data,
                                membro = new Membro { id = r.membro.id, nome = r.membro.nome, cargo = r.membro.cargo },
                                poder = r.poder
                            };

                return await query.ToListAsync();
            }
        }

        // GET: api/RegistrosPoder/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistroPoder>> GetRegistroPoder(long id)
        {
            var query = from r in _context.RegistrosPoder where r.id == id orderby r.data descending
                        select new RegistroPoder
                        {
                            id = r.id,
                            data = r.data,
                            membro = new Membro { id = r.membro.id, nome = r.membro.nome, cargo = r.membro.cargo },
                            poder = r.poder
                        };

            var registroPoder = await query.FirstOrDefaultAsync();

            if (registroPoder == null) {
                return NotFound();
            }

            return registroPoder;
        }

        // PUT: api/RegistrosPoder/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistroPoder(long id, RegistroPoder registroPoder)
        {
            if (id != registroPoder.id)
            {
                return BadRequest();
            }

            _context.Entry(registroPoder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistroPoderExists(id))
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

        // POST: api/RegistrosPoder
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<RegistroPoder>> PostRegistroPoder(RegistroPoder registroPoder)
        {
            _context.RegistrosPoder.Add(registroPoder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistroPoder", new { id = registroPoder.id }, registroPoder);
        }

        // DELETE: api/RegistrosPoder/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RegistroPoder>> DeleteRegistroPoder(long id)
        {
            var registroPoder = await _context.RegistrosPoder.FindAsync(id);
            if (registroPoder == null)
            {
                return NotFound();
            }

            _context.RegistrosPoder.Remove(registroPoder);
            await _context.SaveChangesAsync();

            return registroPoder;
        }

        private bool RegistroPoderExists(long id)
        {
            return _context.RegistrosPoder.Any(e => e.id == id);
        }
    }
}
