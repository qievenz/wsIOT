using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IOT.Models;

namespace IOT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicionController : ControllerBase
    {
        private readonly APIAppDbContext _context;

        public MedicionController(APIAppDbContext context)
        {
            _context = context;
        }

        // GET: api/Medicion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medicion>>> GetMedicion()
        {
            return await _context.Medicion.ToListAsync();
        }

        // GET: api/Medicion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medicion>> GetMedicion(long id)
        {
            var medicion = await _context.Medicion.FindAsync(id);

            if (medicion == null)
            {
                return NotFound();
            }

            return medicion;
        }

        // PUT: api/Medicion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicion(long id, Medicion medicion)
        {
            if (id != medicion.MedicionId)
            {
                return BadRequest();
            }

            _context.Entry(medicion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicionExists(id))
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

        // POST: api/Medicion
        [HttpPost]
        public async Task<ActionResult<Medicion>> PostMedicion(Medicion medicion)
        {
            _context.Medicion.Add(medicion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MedicionExists(medicion.MedicionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMedicion", new { id = medicion.MedicionId }, medicion);
        }

        // DELETE: api/Medicion/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Medicion>> DeleteMedicion(long id)
        {
            var medicion = await _context.Medicion.FindAsync(id);
            if (medicion == null)
            {
                return NotFound();
            }

            _context.Medicion.Remove(medicion);
            await _context.SaveChangesAsync();

            return medicion;
        }

        private bool MedicionExists(long id)
        {
            return _context.Medicion.Any(e => e.MedicionId == id);
        }
    }
}
