using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIJardineria.Models;

namespace APIJardineria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OficinasController : ControllerBase
    {
        private readonly MySQLDbContext _context;

        public OficinasController(MySQLDbContext context)
        {
            _context = context;
        }

        // GET: api/Oficinas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Oficina>>> GetOficina()
        {
            return await _context.Oficina.ToListAsync();
        }

        // GET: api/Oficinas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Oficina>> GetOficina(string id)
        {
            var oficina = await _context.Oficina.FindAsync(id);

            if (oficina == null)
            {
                return NotFound();
            }

            return oficina;
        }

        // PUT: api/Oficinas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOficina(string id, Oficina oficina)
        {
            if (id != oficina.Codigo_Oficina)
            {
                return BadRequest();
            }

            _context.Entry(oficina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OficinaExists(id))
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

        // POST: api/Oficinas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Oficina>> PostOficina(Oficina oficina)
        {
            _context.Oficina.Add(oficina);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OficinaExists(oficina.Codigo_Oficina))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOficina", new { id = oficina.Codigo_Oficina }, oficina);
        }

        // DELETE: api/Oficinas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Oficina>> DeleteOficina(string id)
        {
            var oficina = await _context.Oficina.FindAsync(id);
            if (oficina == null)
            {
                return NotFound();
            }

            _context.Oficina.Remove(oficina);
            await _context.SaveChangesAsync();

            return oficina;
        }

        private bool OficinaExists(string id)
        {
            return _context.Oficina.Any(e => e.Codigo_Oficina == id);
        }
    }
}
