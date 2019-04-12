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
    public class CustoesController : ControllerBase
    {
        private readonly provamarceloContext _context;

        public CustoesController(provamarceloContext context)
        {
            _context = context;
        }

        // GET: api/Custoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Custo>>> GetCusto()
        {
            return await _context.Custo.ToListAsync();
        }

        // GET: api/Custoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Custo>> GetCusto(int id)
        {
            var custo = await _context.Custo.FindAsync(id);

            if (custo == null)
            {
                return NotFound();
            }

            return custo;
        }

        // PUT: api/Custoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCusto(int id, Custo custo)
        {
            if (id != custo.CdCusto)
            {
                return BadRequest();
            }

            _context.Entry(custo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustoExists(id))
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

        // POST: api/Custoes
        [HttpPost]
        public async Task<ActionResult<Custo>> PostCusto(Custo custo)
        {
            _context.Custo.Add(custo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustoExists(custo.CdCusto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCusto", new { id = custo.CdCusto }, custo);
        }

        // DELETE: api/Custoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Custo>> DeleteCusto(int id)
        {
            var custo = await _context.Custo.FindAsync(id);
            if (custo == null)
            {
                return NotFound();
            }

            _context.Custo.Remove(custo);
            await _context.SaveChangesAsync();

            return custo;
        }

        private bool CustoExists(int id)
        {
            return _context.Custo.Any(e => e.CdCusto == id);
        }
    }
}
