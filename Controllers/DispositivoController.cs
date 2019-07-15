using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wsIOT.Models;

namespace wsIOT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DispositivoController : ControllerBase
    {
        private readonly APIAppDbContext _context;

        public DispositivoController(APIAppDbContext context)
        {
            _context = context;
        }

        // GET: api/Dispositivo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dispositivo>>> GetDispositivo()
        {
            return await _context.Dispositivo.ToListAsync();
        }

        // GET: api/Dispositivo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dispositivo>> GetDispositivo(long id)
        {
            var dispositivo = await _context.Dispositivo.FindAsync(id);

            if (dispositivo == null)
            {
                return NotFound();
            }

            return dispositivo;
        }

        // PUT: api/Dispositivo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDispositivo(long id, Dispositivo dispositivo)
        {
            if (id != dispositivo.DispositivoId)
            {
                return BadRequest();
            }

            _context.Entry(dispositivo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DispositivoExists(id))
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

        // POST: api/Dispositivo
        [HttpPost]
        public async Task<ActionResult<Dispositivo>> PostDispositivo(Dispositivo dispositivo)
        {
            _context.Dispositivo.Add(dispositivo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DispositivoExists(dispositivo.DispositivoId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDispositivo", new { id = dispositivo.DispositivoId }, dispositivo);
        }

        // DELETE: api/Dispositivo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dispositivo>> DeleteDispositivo(long id)
        {
            var dispositivo = await _context.Dispositivo.FindAsync(id);
            if (dispositivo == null)
            {
                return NotFound();
            }

            _context.Dispositivo.Remove(dispositivo);
            await _context.SaveChangesAsync();

            return dispositivo;
        }

        private bool DispositivoExists(long id)
        {
            return _context.Dispositivo.Any(e => e.DispositivoId == id);
        }
    }
}
