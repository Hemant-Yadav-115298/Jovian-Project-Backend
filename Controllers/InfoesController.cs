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
    public class InfoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InfoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Infoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Info>>> GetInfo()
        {
            return await _context.Info.ToListAsync();
        }

        // GET: api/Infoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Info>> GetInfo(Guid id)
        {
            var info = await _context.Info.FindAsync(id);

            if (info == null)
            {
                return NotFound();
            }

            return info;
        }

        // PUT: api/Infoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInfo(Guid id, Info info)
        {
            if (id != info.ID)
            {
                return BadRequest();
            }

            _context.Entry(info).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfoExists(id))
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

        // POST: api/Infoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Info>> PostInfo(Info info)
        {
            _context.Info.Add(info);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInfo", new { id = info.ID }, info);
        }

        // DELETE: api/Infoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInfo(Guid id)
        {
            var info = await _context.Info.FindAsync(id);
            if (info == null)
            {
                return NotFound();
            }

            _context.Info.Remove(info);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Infoes/by-actor/{actorId}
        [HttpGet("by-actor/{actorId}")]
        public async Task<ActionResult<IEnumerable<InfoSummaryDto>>> GetInfosByActor(Guid actorId)
        {
            var infos = await _context.ActorsActor
                .Where(ia => ia.ActorID == actorId)
                .Select(ia => new InfoSummaryDto
                {
                    ID = ia.Info.ID,
                    Name = ia.Info.Name,
                    RepoName = ia.Info.RepoName,
                    ScanDate = ia.Info.ScanDate,
                    IsUpdated = ia.Info.IsUpdated,
                    IsDeleted = ia.Info.IsDeleted,
                    UpdatedOn = ia.Info.UpdatedOn,
                    DeletedOn = ia.Info.DeletedOn,
                    Status = ia.Info.Status
                })
                .ToListAsync();

            return Ok(infos);
        }

        // GET: api/Infoes/threat-details/{infoId}
        [HttpGet("threat-details/{infoId}")]
        public async Task<ActionResult<InfoThreatDetailsDto>> GetThreatDetailsByInfoId(Guid infoId)
        {
            var info = await _context.Info.FindAsync(infoId);
            if (info == null)
                return NotFound();

            var threats = await _context.Threat.Where(t => t.InfoID == infoId).ToListAsync();
            var diagrams = await _context.ThreatDiagram.Where(d => d.InfoID == infoId).ToListAsync();

            var result = new InfoThreatDetailsDto
            {
                Info = info,
                Threats = threats,
                ThreatDiagrams = diagrams
            };

            return Ok(result);
        }

        private bool InfoExists(Guid id)
        {
            return _context.Info.Any(e => e.ID == id);
        }
    }
}
