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
    public class InfoActorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InfoActorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/InfoActors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InfoActor>>> GetActorsActor()
        {
            return await _context.ActorsActor.ToListAsync();
        }

        // GET: api/InfoActors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InfoActor>> GetInfoActor(Guid id)
        {
            var infoActor = await _context.ActorsActor.FindAsync(id);

            if (infoActor == null)
            {
                return NotFound();
            }

            return infoActor;
        }

        // PUT: api/InfoActors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInfoActor(Guid id, InfoActor infoActor)
        {
            if (id != infoActor.ID)
            {
                return BadRequest();
            }

            _context.Entry(infoActor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfoActorExists(id))
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

        // POST: api/InfoActors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InfoActor>> PostInfoActor(InfoActor infoActor)
        {
            _context.ActorsActor.Add(infoActor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInfoActor", new { id = infoActor.ID }, infoActor);
        }

        // DELETE: api/InfoActors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInfoActor(Guid id)
        {
            var infoActor = await _context.ActorsActor.FindAsync(id);
            if (infoActor == null)
            {
                return NotFound();
            }

            _context.ActorsActor.Remove(infoActor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InfoActorExists(Guid id)
        {
            return _context.ActorsActor.Any(e => e.ID == id);
        }
    }
}
