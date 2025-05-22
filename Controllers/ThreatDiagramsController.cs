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
    public class ThreatDiagramsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ThreatDiagramsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ThreatDiagrams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThreatDiagram>>> GetThreatDiagram()
        {
            return await _context.ThreatDiagram.ToListAsync();
        }

        // GET: api/ThreatDiagrams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ThreatDiagram>> GetThreatDiagram(Guid id)
        {
            var threatDiagram = await _context.ThreatDiagram.FindAsync(id);

            if (threatDiagram == null)
            {
                return NotFound();
            }

            return threatDiagram;
        }

        // PUT: api/ThreatDiagrams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThreatDiagram(Guid id, ThreatDiagram threatDiagram)
        {
            if (id != threatDiagram.ID)
            {
                return BadRequest();
            }

            _context.Entry(threatDiagram).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThreatDiagramExists(id))
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

        // POST: api/ThreatDiagrams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ThreatDiagram>> PostThreatDiagram(ThreatDiagram threatDiagram)
        {
            _context.ThreatDiagram.Add(threatDiagram);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThreatDiagram", new { id = threatDiagram.ID }, threatDiagram);
        }

        // DELETE: api/ThreatDiagrams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThreatDiagram(Guid id)
        {
            var threatDiagram = await _context.ThreatDiagram.FindAsync(id);
            if (threatDiagram == null)
            {
                return NotFound();
            }

            _context.ThreatDiagram.Remove(threatDiagram);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ThreatDiagramExists(Guid id)
        {
            return _context.ThreatDiagram.Any(e => e.ID == id);
        }
    }
}
