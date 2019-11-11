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
    public class RegistrosChefeController : ControllerBase
    {
        private readonly GuildManagerContext _context;

        public RegistrosChefeController(GuildManagerContext context)
        {
            _context = context;
        }

        // GET: api/RegistrosChefe
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistroChefe>>> GetRegistrosChefe()
        {
            return await _context.RegistrosChefe.ToListAsync();
        }

        // GET: api/RegistrosChefe/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistroChefe>> GetRegistroChefe(long id)
        {
            var registroChefe = await _context.RegistrosChefe.FindAsync(id);

            if (registroChefe == null)
            {
                return NotFound();
            }

            return registroChefe;
        }

        // PUT: api/RegistrosChefe/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistroChefe(long id, RegistroChefe registroChefe)
        {
            if (id != registroChefe.id)
            {
                return BadRequest();
            }

            _context.Entry(registroChefe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistroChefeExists(id))
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

        // POST: api/RegistrosChefe
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<RegistroChefe>> PostRegistroChefe(RegistroChefe registroChefe)
        {
            _context.RegistrosChefe.Add(registroChefe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistroChefe", new { id = registroChefe.id }, registroChefe);
        }

        // DELETE: api/RegistrosChefe/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RegistroChefe>> DeleteRegistroChefe(long id)
        {
            var registroChefe = await _context.RegistrosChefe.FindAsync(id);
            if (registroChefe == null)
            {
                return NotFound();
            }

            _context.RegistrosChefe.Remove(registroChefe);
            await _context.SaveChangesAsync();

            return registroChefe;
        }

        private bool RegistroChefeExists(long id)
        {
            return _context.RegistrosChefe.Any(e => e.id == id);
        }
    }
}
