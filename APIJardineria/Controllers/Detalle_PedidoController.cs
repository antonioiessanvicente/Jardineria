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
    public class Detalle_PedidoController : ControllerBase
    {
        private readonly MySQLDbContext _context;

        public Detalle_PedidoController(MySQLDbContext context)
        {
            _context = context;
        }

        // GET: api/Detalle_Pedido
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Detalle_Pedido>>> GetDetalle_Pedido()
        {
            return await _context.Detalle_Pedido.ToListAsync();
        }

        // GET: api/Detalle_Pedido/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Detalle_Pedido>>> GetDetalle_Pedido([FromRoute] int id)
        {
           if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var detalle_Pedido =  await _context.Detalle_Pedido.Where(x => x.Codigo_Pedido == id).ToListAsync();

            if (detalle_Pedido == null)
            {
                return NotFound();
            }

            return detalle_Pedido;
        }

        // GET: api/Detalle_Pedido/5/1
        [HttpGet("{id:int}/{numero_linea:int}")]
        public async Task<IActionResult> GetDetalle_Pedido([FromRoute] int id, int numero_linea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            object[] param = new object[] { id, numero_linea };
            var detalle = await _context.Detalle_Pedido.FindAsync(param);

            if (detalle == null)
            {
                return NotFound();
            }

            return Ok(detalle);
        }



        // PUT: api/Detalle_Pedido/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        //public async Task<IActionResult> PutDetalle_Pedido(int id, Detalle_Pedido detalle_Pedido)
        //{
        //    if (id != detalle_Pedido.Codigo_Pedido)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(detalle_Pedido).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!Detalle_PedidoExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}


        // PUT: api/Detalle_Pedido/5/1
        [HttpPut("{id:int}/{numero_linea:int}")]
        public async Task<IActionResult> PutDetalle_Pedido([FromRoute] int id, [FromBody] Detalle_Pedido detalle_Pedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != detalle_Pedido.Codigo_Pedido)
            {
                return BadRequest();
            }

            _context.Entry(detalle_Pedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Detalle_PedidoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(detalle_Pedido);
        }


        // POST: api/Detalle_Pedido
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Detalle_Pedido>> PostDetalle_Pedido(Detalle_Pedido detalle_Pedido)
        {
            _context.Detalle_Pedido.Add(detalle_Pedido);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Detalle_PedidoExists(detalle_Pedido.Codigo_Pedido))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDetalle_Pedido", new { id = detalle_Pedido.Codigo_Pedido }, detalle_Pedido);
        }

        //// DELETE: api/Detalle_Pedido/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Detalle_Pedido>> DeleteDetalle_Pedido(int id)
        //{
        //    var detalle_Pedido = await _context.Detalle_Pedido.FindAsync(id);
        //    if (detalle_Pedido == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Detalle_Pedido.Remove(detalle_Pedido);
        //    await _context.SaveChangesAsync();

        //    return detalle_Pedido;
        //}
        // DELETE: api/Detalle_Pedido/5/1
        [HttpDelete("{id:int}/{numero_linea:int}")]
        public async Task<IActionResult> DeleteDetalle_Pedido([FromRoute] int id, int id_linea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            object[] param = new object[] { id, id_linea };
            var detalle_Pedido = await _context.Detalle_Pedido.FindAsync(param);

            if (detalle_Pedido == null)
            {
                return NotFound();
            }

            _context.Detalle_Pedido.Remove(detalle_Pedido);
            await _context.SaveChangesAsync();

            return Ok(detalle_Pedido);
        }
        private bool Detalle_PedidoExists(int id)
        {
            return _context.Detalle_Pedido.Any(e => e.Codigo_Pedido == id);
        }
    }
}
