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
    public class SensorController : ControllerBase
    {
        private readonly APIAppDbContext _context;

        public SensorController(APIAppDbContext context)
        {
            _context = context;
        }

        // GET: api/Sensor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sensor>>> GetSensor()
        {
            return await _context.Sensor.ToListAsync();
        }

        // GET: api/Sensor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sensor>> GetSensor(long id)
        {
            var sensor = await _context.Sensor.FindAsync(id);

            if (sensor == null)
            {
                return NotFound();
            }

            return sensor;
        }

        // PUT: api/Sensor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSensor(long id, Sensor sensor)
        {
            if (id != sensor.SensorId)
            {
                return BadRequest();
            }

            _context.Entry(sensor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SensorExists(id))
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

        // POST: api/Sensor
        [HttpPost]
        public async Task<ActionResult<Sensor>> PostSensor(Sensor sensor)
        {
            _context.Sensor.Add(sensor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SensorExists(sensor.SensorId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSensor", new { id = sensor.SensorId }, sensor);
        }

        // DELETE: api/Sensor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sensor>> DeleteSensor(long id)
        {
            var sensor = await _context.Sensor.FindAsync(id);
            if (sensor == null)
            {
                return NotFound();
            }

            _context.Sensor.Remove(sensor);
            await _context.SaveChangesAsync();

            return sensor;
        }

        private bool SensorExists(long id)
        {
            return _context.Sensor.Any(e => e.SensorId == id);
        }
    }
}
