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
    public class EventStationAssignmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventStationAssignmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EventStationAssignments
        [HttpGet]
        public IEnumerable<EventStationAssignment> GetEventStationAssignments()
        {
            return _context.EventStationAssignments;
        }

        // GET: api/EventStationAssignments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventStationAssignment([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eventStationAssignment = await _context.EventStationAssignments.FindAsync(id);

            if (eventStationAssignment == null)
            {
                return NotFound();
            }

            return Ok(eventStationAssignment);
        }

        // PUT: api/EventStationAssignments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventStationAssignment([FromRoute] Guid id, [FromBody] EventStationAssignment eventStationAssignment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventStationAssignment.EventId)
            {
                return BadRequest();
            }

            _context.Entry(eventStationAssignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventStationAssignmentExists(id))
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

        // POST: api/EventStationAssignments
        [HttpPost]
        public async Task<IActionResult> PostEventStationAssignment([FromBody] EventStationAssignment eventStationAssignment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EventStationAssignments.Add(eventStationAssignment);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EventStationAssignmentExists(eventStationAssignment.EventId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEventStationAssignment", new { id = eventStationAssignment.EventId }, eventStationAssignment);
        }

        // DELETE: api/EventStationAssignments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventStationAssignment([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eventStationAssignment = await _context.EventStationAssignments.FindAsync(id);
            if (eventStationAssignment == null)
            {
                return NotFound();
            }

            _context.EventStationAssignments.Remove(eventStationAssignment);
            await _context.SaveChangesAsync();

            return Ok(eventStationAssignment);
        }

        private bool EventStationAssignmentExists(Guid id)
        {
            return _context.EventStationAssignments.Any(e => e.EventId == id);
        }
    }
}