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
    public class TourController : ControllerBase
    {
        private readonly DataContext _context;

        public TourController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Tour
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tour>>> GetTour()
        {
          if (_context.Tour == null)
          {
              return NotFound();
          }
            return await _context.Tour.ToListAsync();
        }

        // GET: api/Tour/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tour>> GetTour(long id)
        {
          if (_context.Tour == null)
          {
              return NotFound();
          }
            var tour = await _context.Tour.FindAsync(id);

            if (tour == null)
            {
                return NotFound();
            }

            return tour;
        }

        // PUT: api/Tour/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTour(long id, Tour tour)
        {
            if (id != tour.TourId)
            {
                return BadRequest();
            }

            _context.Entry(tour).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourExists(id))
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

        // POST: api/Tour
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tour>> PostTour(Tour tour)
        {
          if (_context.Tour == null)
          {
              return Problem("Entity set 'DataContext.Tour'  is null.");
          }
            _context.Tour.Add(tour);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTour", new { id = tour.TourId }, tour);
        }

        // DELETE: api/Tour/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTour(long id)
        {
            if (_context.Tour == null)
            {
                return NotFound();
            }
            var tour = await _context.Tour.FindAsync(id);
            if (tour == null)
            {
                return NotFound();
            }

            _context.Tour.Remove(tour);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TourExists(long id)
        {
            return (_context.Tour?.Any(e => e.TourId == id)).GetValueOrDefault();
        }
    }
}
