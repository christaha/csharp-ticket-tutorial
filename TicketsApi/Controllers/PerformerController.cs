using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketsApi.Models;

namespace TicketsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformerController : ControllerBase
    {
        private readonly DataContext _context;

        public PerformerController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Performer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Performer>>> GetPerformer()
        {
          if (_context.Performer == null)
          {
              return NotFound();
          }
            return await _context.Performer.ToListAsync();
        }

        // GET: api/Performer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Performer>> GetPerformer(long id)
        {
          if (_context.Performer == null)
          {
              return NotFound();
          }
            var performer = await _context.Performer.FindAsync(id);

            if (performer == null)
            {
                return NotFound();
            }

            return performer;
        }

        // PUT: api/Performer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerformer(long id, Performer performer)
        {
            if (id != performer.PerformerId)
            {
                return BadRequest();
            }

            _context.Entry(performer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerformerExists(id))
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

        // POST: api/Performer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Performer>> PostPerformer(Performer performer)
        {
          if (_context.Performer == null)
          {
              return Problem("Entity set 'DataContext.Performer'  is null.");
          }
            _context.Performer.Add(performer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerformer", new { id = performer.PerformerId }, performer);
        }

        // DELETE: api/Performer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerformer(long id)
        {
            if (_context.Performer == null)
            {
                return NotFound();
            }
            var performer = await _context.Performer.FindAsync(id);
            if (performer == null)
            {
                return NotFound();
            }

            _context.Performer.Remove(performer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PerformerExists(long id)
        {
            return (_context.Performer?.Any(e => e.PerformerId == id)).GetValueOrDefault();
        }
    }
}
