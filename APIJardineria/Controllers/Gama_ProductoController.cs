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
    public class Gama_ProductoController : ControllerBase
    {
        private readonly MySQLDbContext _context;

        public Gama_ProductoController(MySQLDbContext context)
        {
            _context = context;
        }

        // GET: api/Gama_Producto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gama_Producto>>> Getgama_Producto()
        {
            return await _context.gama_Producto.ToListAsync();
        }

        // GET: api/Gama_Producto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gama_Producto>> GetGama_Producto(string id)
        {
            var gama_Producto = await _context.gama_Producto.FindAsync(id);

            if (gama_Producto == null)
            {
                return NotFound();
            }

            return gama_Producto;
        }

        // PUT: api/Gama_Producto/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGama_Producto(string id, Gama_Producto gama_Producto)
        {
            if (id != gama_Producto.Gama)
            {
                return BadRequest();
            }

            _context.Entry(gama_Producto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Gama_ProductoExists(id))
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

        // POST: api/Gama_Producto
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Gama_Producto>> PostGama_Producto(Gama_Producto gama_Producto)
        {
            _context.gama_Producto.Add(gama_Producto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Gama_ProductoExists(gama_Producto.Gama))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGama_Producto", new { id = gama_Producto.Gama }, gama_Producto);
        }

        // DELETE: api/Gama_Producto/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Gama_Producto>> DeleteGama_Producto(string id)
        {
            var gama_Producto = await _context.gama_Producto.FindAsync(id);
            if (gama_Producto == null)
            {
                return NotFound();
            }

            _context.gama_Producto.Remove(gama_Producto);
            await _context.SaveChangesAsync();

            return gama_Producto;
        }

        private bool Gama_ProductoExists(string id)
        {
            return _context.gama_Producto.Any(e => e.Gama == id);
        }
    }
}
