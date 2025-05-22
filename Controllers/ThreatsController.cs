using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Jovian_Project_Backend.Data;
using Jovian_Project_Backend.Models;

namespace Jovian_Project_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThreatsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ThreatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Threats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Threat>>> GetThreat()
        {
            return await _context.Threat.ToListAsync();
        }

        // GET: api/Threats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Threat>> GetThreat(Guid id)
        {
            var threat = await _context.Threat.FindAsync(id);

            if (threat == null)
            {
                return NotFound();
            }

            return threat;
        }

        // PUT: api/Threats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThreat(Guid id, Threat threat)
        {
            if (id != threat.ID)
            {
                return BadRequest();
            }

            _context.Entry(threat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThreatExists(id))
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

        // POST: api/Threats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Threat>> PostThreat(Threat threat)
        {
            _context.Threat.Add(threat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThreat", new { id = threat.ID }, threat);
        }

        // DELETE: api/Threats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThreat(Guid id)
        {
            var threat = await _context.Threat.FindAsync(id);
            if (threat == null)
            {
                return NotFound();
            }

            _context.Threat.Remove(threat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ThreatExists(Guid id)
        {
            return _context.Threat.Any(e => e.ID == id);
        }
    }
}
