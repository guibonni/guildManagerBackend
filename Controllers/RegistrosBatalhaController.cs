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

        // GET: api/RegistrosBatalha?resumido=false
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Object>>> GetRegistrosBatalha([FromQuery] bool resumido)
        {
            if (resumido) {
                var query = from r in _context.RegistrosBatalha orderby r.data descending
                            select new
                            {
                                id = r.id,
                                data = r.data.ToShortDateString(),
                                membro = r.membro.nome
                            };

                return await query.ToListAsync();
            } else {
                var query = from r in _context.RegistrosBatalha
                            select new RegistroBatalha
                            {
                                id = r.id,
                                data = r.data,
                                membro = new Membro { id = r.membro.id, nome = r.membro.nome, cargo = r.membro.cargo },
                                defesa = r.defesa,
                                equipeAtaque = new Equipe
                                {
                                    id = r.equipeAtaque.id,
                                    personagem1 = new Personagem
                                    {
                                        id = r.equipeAtaque.personagem1.id,
                                        nome = r.equipeAtaque.personagem1.nome,
                                        classe = r.equipeAtaque.personagem1.classe
                                    },
                                    personagem2 = new Personagem
                                    {
                                        id = r.equipeAtaque.personagem2.id,
                                        nome = r.equipeAtaque.personagem2.nome,
                                        classe = r.equipeAtaque.personagem2.classe
                                    },
                                    personagem3 = new Personagem
                                    {
                                        id = r.equipeAtaque.personagem3.id,
                                        nome = r.equipeAtaque.personagem3.nome,
                                        classe = r.equipeAtaque.personagem3.classe
                                    },
                                    personagem4 = new Personagem
                                    {
                                        id = r.equipeAtaque.personagem4.id,
                                        nome = r.equipeAtaque.personagem4.nome,
                                        classe = r.equipeAtaque.personagem4.classe
                                    },
                                    personagem5 = new Personagem
                                    {
                                        id = r.equipeAtaque.personagem5.id,
                                        nome = r.equipeAtaque.personagem5.nome,
                                        classe = r.equipeAtaque.personagem5.classe
                                    },
                                    personagem6 = new Personagem
                                    {
                                        id = r.equipeAtaque.personagem6.id,
                                        nome = r.equipeAtaque.personagem6.nome,
                                        classe = r.equipeAtaque.personagem6.classe
                                    },
                                    mascote1 = r.equipeAtaque.mascote1,
                                    mascote2 = r.equipeAtaque.mascote2
                                },
                                equipeDefesa = new Equipe
                                {
                                    id = r.equipeDefesa.id,
                                    personagem1 = new Personagem
                                    {
                                        id = r.equipeDefesa.personagem1.id,
                                        nome = r.equipeDefesa.personagem1.nome,
                                        classe = r.equipeDefesa.personagem1.classe
                                    },
                                    personagem2 = new Personagem
                                    {
                                        id = r.equipeDefesa.personagem2.id,
                                        nome = r.equipeDefesa.personagem2.nome,
                                        classe = r.equipeDefesa.personagem2.classe
                                    },
                                    personagem3 = new Personagem
                                    {
                                        id = r.equipeDefesa.personagem3.id,
                                        nome = r.equipeDefesa.personagem3.nome,
                                        classe = r.equipeDefesa.personagem3.classe
                                    },
                                    personagem4 = new Personagem
                                    {
                                        id = r.equipeDefesa.personagem4.id,
                                        nome = r.equipeDefesa.personagem4.nome,
                                        classe = r.equipeDefesa.personagem4.classe
                                    },
                                    personagem5 = new Personagem
                                    {
                                        id = r.equipeDefesa.personagem5.id,
                                        nome = r.equipeDefesa.personagem5.nome,
                                        classe = r.equipeDefesa.personagem5.classe
                                    },
                                    personagem6 = new Personagem
                                    {
                                        id = r.equipeDefesa.personagem6.id,
                                        nome = r.equipeDefesa.personagem6.nome,
                                        classe = r.equipeDefesa.personagem6.classe
                                    },
                                    mascote1 = r.equipeDefesa.mascote1,
                                    mascote2 = r.equipeDefesa.mascote2
                                },
                                primeiroAtaque = r.primeiroAtaque,
                                segundoAtaque = r.segundoAtaque
                            };

                return await query.ToListAsync();
            }
        }

        // GET: api/RegistrosBatalha/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistroBatalha>> GetRegistroBatalha(long id)
        {
            var query = from r in _context.RegistrosBatalha where r.id == id
                        select new RegistroBatalha
                        {
                            id = r.id,
                            data = r.data,
                            membro = new Membro { id = r.membro.id, nome = r.membro.nome, cargo = r.membro.cargo },
                            defesa = r.defesa,
                            equipeAtaque = new Equipe
                            {
                                id = r.equipeAtaque.id,
                                personagem1 = new Personagem
                                {
                                    id = r.equipeAtaque.personagem1.id,
                                    nome = r.equipeAtaque.personagem1.nome,
                                    classe = r.equipeAtaque.personagem1.classe
                                },
                                personagem2 = new Personagem
                                {
                                    id = r.equipeAtaque.personagem2.id,
                                    nome = r.equipeAtaque.personagem2.nome,
                                    classe = r.equipeAtaque.personagem2.classe
                                },
                                personagem3 = new Personagem
                                {
                                    id = r.equipeAtaque.personagem3.id,
                                    nome = r.equipeAtaque.personagem3.nome,
                                    classe = r.equipeAtaque.personagem3.classe
                                },
                                personagem4 = new Personagem
                                {
                                    id = r.equipeAtaque.personagem4.id,
                                    nome = r.equipeAtaque.personagem4.nome,
                                    classe = r.equipeAtaque.personagem4.classe
                                },
                                personagem5 = new Personagem
                                {
                                    id = r.equipeAtaque.personagem5.id,
                                    nome = r.equipeAtaque.personagem5.nome,
                                    classe = r.equipeAtaque.personagem5.classe
                                },
                                personagem6 = new Personagem
                                {
                                    id = r.equipeAtaque.personagem6.id,
                                    nome = r.equipeAtaque.personagem6.nome,
                                    classe = r.equipeAtaque.personagem6.classe
                                },
                                mascote1 = r.equipeAtaque.mascote1,
                                mascote2 = r.equipeAtaque.mascote2
                            },
                            equipeDefesa = new Equipe
                            {
                                id = r.equipeDefesa.id,
                                personagem1 = new Personagem
                                {
                                    id = r.equipeDefesa.personagem1.id,
                                    nome = r.equipeDefesa.personagem1.nome,
                                    classe = r.equipeDefesa.personagem1.classe
                                },
                                personagem2 = new Personagem
                                {
                                    id = r.equipeDefesa.personagem2.id,
                                    nome = r.equipeDefesa.personagem2.nome,
                                    classe = r.equipeDefesa.personagem2.classe
                                },
                                personagem3 = new Personagem
                                {
                                    id = r.equipeDefesa.personagem3.id,
                                    nome = r.equipeDefesa.personagem3.nome,
                                    classe = r.equipeDefesa.personagem3.classe
                                },
                                personagem4 = new Personagem
                                {
                                    id = r.equipeDefesa.personagem4.id,
                                    nome = r.equipeDefesa.personagem4.nome,
                                    classe = r.equipeDefesa.personagem4.classe
                                },
                                personagem5 = new Personagem
                                {
                                    id = r.equipeDefesa.personagem5.id,
                                    nome = r.equipeDefesa.personagem5.nome,
                                    classe = r.equipeDefesa.personagem5.classe
                                },
                                personagem6 = new Personagem
                                {
                                    id = r.equipeDefesa.personagem6.id,
                                    nome = r.equipeDefesa.personagem6.nome,
                                    classe = r.equipeDefesa.personagem6.classe
                                },
                                mascote1 = r.equipeDefesa.mascote1,
                                mascote2 = r.equipeDefesa.mascote2
                            },
                            primeiroAtaque = r.primeiroAtaque,
                            segundoAtaque = r.segundoAtaque
                        };

            var registroBatalha = await query.FirstOrDefaultAsync();

            if (registroBatalha == null) {
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
