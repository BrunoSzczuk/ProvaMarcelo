using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BrunoSzczuk.Models;

namespace BrunoSzczuk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinoesController : ControllerBase
    {
        private readonly provamarceloContext _context;

        public DestinoesController(provamarceloContext context)
        {
            _context = context;
        }

        // GET: api/Destinoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Destino>>> GetDestino()
        {
            return await _context.Destino.ToListAsync();
        }

        // GET: api/Destinoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Destino>> GetDestino(int id)
        {
            var destino = await _context.Destino.FindAsync(id);

            if (destino == null)
            {
                return NotFound();
            }

            return destino;
        }

        // PUT: api/Destinoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDestino(int id, Destino destino)
        {
            if (id != destino.CdDestino)
            {
                return BadRequest();
            }

            _context.Entry(destino).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DestinoExists(id))
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

        // POST: api/Destinoes
        [HttpPost]
        public async Task<ActionResult<Destino>> PostDestino(Destino destino)
        {
            _context.Destino.Add(destino);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DestinoExists(destino.CdDestino))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDestino", new { id = destino.CdDestino }, destino);
        }

        // DELETE: api/Destinoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Destino>> DeleteDestino(int id)
        {
            var destino = await _context.Destino.FindAsync(id);
            if (destino == null)
            {
                return NotFound();
            }

            _context.Destino.Remove(destino);
            await _context.SaveChangesAsync();

            return destino;
        }

        private bool DestinoExists(int id)
        {
            return _context.Destino.Any(e => e.CdDestino == id);
        }
    }
}
