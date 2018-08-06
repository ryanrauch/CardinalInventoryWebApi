using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CardinalInventoryWebApi.Data;
using CardinalInventoryWebApi.Data.EventManagement;

namespace CardinalInventoryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventStationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventStationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EventStations
        [HttpGet]
        public IEnumerable<EventStation> GetEventStations()
        {
            return _context.EventStations;
        }

        // GET: api/EventStations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventStation([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eventStation = await _context.EventStations.FindAsync(id);

            if (eventStation == null)
            {
                return NotFound();
            }

            return Ok(eventStation);
        }

        // PUT: api/EventStations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventStation([FromRoute] Guid id, [FromBody] EventStation eventStation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventStation.EventStationId)
            {
                return BadRequest();
            }

            _context.Entry(eventStation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventStationExists(id))
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

        // POST: api/EventStations
        [HttpPost]
        public async Task<IActionResult> PostEventStation([FromBody] EventStation eventStation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EventStations.Add(eventStation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventStation", new { id = eventStation.EventStationId }, eventStation);
        }

        // DELETE: api/EventStations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventStation([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eventStation = await _context.EventStations.FindAsync(id);
            if (eventStation == null)
            {
                return NotFound();
            }

            _context.EventStations.Remove(eventStation);
            await _context.SaveChangesAsync();

            return Ok(eventStation);
        }

        private bool EventStationExists(Guid id)
        {
            return _context.EventStations.Any(e => e.EventStationId == id);
        }
    }
}