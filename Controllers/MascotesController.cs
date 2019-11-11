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
    public class MascotesController : ControllerBase
    {
        private readonly GuildManagerContext _context;

        public MascotesController(GuildManagerContext context)
        {
            _context = context;
        }

        // GET: api/Mascotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mascote>>> GetMascotes()
        {
            return await _context.Mascotes.ToListAsync();
        }

        // GET: api/Mascotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mascote>> GetMascote(long id)
        {
            var mascote = await _context.Mascotes.FindAsync(id);

            if (mascote == null)
            {
                return NotFound();
            }

            return mascote;
        }

        // PUT: api/Mascotes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMascote(long id, Mascote mascote)
        {
            if (id != mascote.id)
            {
                return BadRequest();
            }

            _context.Entry(mascote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MascoteExists(id))
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

        // POST: api/Mascotes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Mascote>> PostMascote(Mascote mascote)
        {
            _context.Mascotes.Add(mascote);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMascote", new { id = mascote.id }, mascote);
        }

        // DELETE: api/Mascotes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Mascote>> DeleteMascote(long id)
        {
            var mascote = await _context.Mascotes.FindAsync(id);
            if (mascote == null)
            {
                return NotFound();
            }

            _context.Mascotes.Remove(mascote);
            await _context.SaveChangesAsync();

            return mascote;
        }

        private bool MascoteExists(long id)
        {
            return _context.Mascotes.Any(e => e.id == id);
        }
    }
}
