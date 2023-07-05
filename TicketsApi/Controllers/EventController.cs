using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketsApi.Models;
using TicketsApi.Error;

namespace TicketsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly DataContext _context;

        public EventController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Event
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvent(long? performerId)
        {
            if (_context.Event == null)
            {
                return NotFound();
            }

            IQueryable<Event> events = from e in _context.Event select e;

            if (performerId.HasValue)
            {
                events = events.Include(x => x.Performers).Where(e => e.Performers.Any(p => p.PerformerId == performerId));
            };

            return await events.ToListAsync();
        }

        // GET: api/Event/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(long id)
        {
          if (_context.Event == null)
          {
              return NotFound();
          }
            var newEvent = await _context.Event.FindAsync(id);

            if (newEvent == null)
            {
                return NotFound();
            }

            return newEvent;
        }

        // PUT: api/Event/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(long id, Event newEvent)
        {
            if (id != newEvent.EventId)
            {
                return BadRequest();
            }

            _context.Entry(newEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
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

        // PUT: api/Event/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("performer/{id}")]
        public async Task<IActionResult> PutEventPerformer(long id, [FromBody] NewEventPerfomer newEventPerformer)
        {
            var foundEvent = _context.Event.Find(id);

            if (foundEvent is null)
            {
                return NotFound("Event not found!");
            }

            foreach (long pid in newEventPerformer.performerIds)
            {
                var foundPerformer = _context.Performer.Find(pid);

                if (foundPerformer is null)
                {
                    return NotFound("Performer Not Found!");
                }

                _context.Entry(foundEvent).State = EntityState.Modified;
                foundEvent.Performers.Add(foundPerformer);
                await _context.SaveChangesAsync();
            }

            return NoContent();
        }

        // POST: api/Event
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(
            [FromBody] NewEvent newEvent)
        {
          if (_context.Event == null)
          {
              return Problem("Entity set 'DataContext.Event'  is null.");
          }

            Location? location = _context.Location.Find(newEvent.LocationId);

            if (location is null)
            {
                return Problem("Location not Found!");
            }

            Event eventToAdd = new Event {
                Location = location,
                LocationId = newEvent.LocationId,
                EventName = newEvent.EventName,
                TicketsAvailable = 0,
                TicketsSold = 0,
                AddedTime = newEvent.StartTime,
                LiveTime = newEvent.LiveTime,
                StartTime = newEvent.StartTime,
                EndTime = newEvent.EndTime,
            };

        _context.Event.Add(eventToAdd);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvent", new { id = eventToAdd.EventId }, eventToAdd);
        }

        // DELETE: api/Event/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(long id)
        {
            if (_context.Event == null)
            {
                return NotFound();
            }
            var newEvent = await _context.Event.FindAsync(id);
            if (newEvent == null)
            {
                return NotFound();
            }

            _context.Event.Remove(newEvent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventExists(long id)
        {
            return (_context.Event?.Any(e => e.EventId == id)).GetValueOrDefault();
        }
    }
}
