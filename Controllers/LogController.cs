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
    public class LogController : ControllerBase
    {
        private readonly APIAppDbContext _context;

        public LogController(APIAppDbContext context)
        {
            _context = context;
        }

        // GET: api/Log
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Log>>> GetLog()
        {
            return await _context.Log.ToListAsync();
        }

        // GET: api/Log/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Log>> GetLog(string id)
        {
            var log = await _context.Log.FindAsync(id);

            if (log == null)
            {
                return NotFound();
            }

            return log;
        }

        // PUT: api/Log/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLog(string id, Log log)
        {
            if (id != log.LogId)
            {
                return BadRequest();
            }

            _context.Entry(log).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogExists(id))
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

        // POST: api/Log
        [HttpPost]
        public async Task<ActionResult<Log>> PostLog(Log log)
        {
            _context.Log.Add(log);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLog", new { id = log.LogId }, log);
        }

        // DELETE: api/Log/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Log>> DeleteLog(string id)
        {
            var log = await _context.Log.FindAsync(id);
            if (log == null)
            {
                return NotFound();
            }

            _context.Log.Remove(log);
            await _context.SaveChangesAsync();

            return log;
        }

        private bool LogExists(string id)
        {
            return _context.Log.Any(e => e.LogId == id);
        }
    }
}
