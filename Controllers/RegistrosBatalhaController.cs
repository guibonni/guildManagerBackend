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
    public class RegistrosBatalhaController : ControllerBase
    {
        private readonly GuildManagerContext _context;

        public RegistrosBatalhaController(GuildManagerContext context)
        {
            _context = context;
        }

        // GET: api/RegistrosBatalha
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistroBatalha>>> GetRegistrosBatalha()
        {
            return await _context.RegistrosBatalha.ToListAsync();
        }

        // GET: api/RegistrosBatalha/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistroBatalha>> GetRegistroBatalha(long id)
        {
            var registroBatalha = await _context.RegistrosBatalha.FindAsync(id);

            if (registroBatalha == null)
            {
                return NotFound();
            }

            return registroBatalha;
        }

        // PUT: api/RegistrosBatalha/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistroBatalha(long id, RegistroBatalha registroBatalha)
        {
            if (id != registroBatalha.id)
            {
                return BadRequest();
            }

            _context.Entry(registroBatalha).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistroBatalhaExists(id))
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

        // POST: api/RegistrosBatalha
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<RegistroBatalha>> PostRegistroBatalha(RegistroBatalha registroBatalha)
        {
            _context.RegistrosBatalha.Add(registroBatalha);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistroBatalha", new { id = registroBatalha.id }, registroBatalha);
        }

        // DELETE: api/RegistrosBatalha/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RegistroBatalha>> DeleteRegistroBatalha(long id)
        {
            var registroBatalha = await _context.RegistrosBatalha.FindAsync(id);
            if (registroBatalha == null)
            {
                return NotFound();
            }

            _context.RegistrosBatalha.Remove(registroBatalha);
            await _context.SaveChangesAsync();

            return registroBatalha;
        }

        private bool RegistroBatalhaExists(long id)
        {
            return _context.RegistrosBatalha.Any(e => e.id == id);
        }
    }
}
