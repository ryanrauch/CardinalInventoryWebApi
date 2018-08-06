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
    public class EventTicketStatusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventTicketStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EventTicketStatus
        [HttpGet]
        public IEnumerable<EventTicketStatus> GetEventTicketStatuses()
        {
            return _context.EventTicketStatuses;
        }

        // GET: api/EventTicketStatus/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventTicketStatus([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eventTicketStatus = await _context.EventTicketStatuses.FindAsync(id);

            if (eventTicketStatus == null)
            {
                return NotFound();
            }

            return Ok(eventTicketStatus);
        }

        /*
        // PUT: api/EventTicketStatus/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventTicketStatus([FromRoute] Guid id, [FromBody] EventTicketStatus eventTicketStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventTicketStatus.EventTicketId)
            {
                return BadRequest();
            }

            _context.Entry(eventTicketStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventTicketStatusExists(id))
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

        // POST: api/EventTicketStatus
        [HttpPost]
        public async Task<IActionResult> PostEventTicketStatus([FromBody] EventTicketStatus eventTicketStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EventTicketStatuses.Add(eventTicketStatus);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EventTicketStatusExists(eventTicketStatus.EventTicketId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEventTicketStatus", new { id = eventTicketStatus.EventTicketId }, eventTicketStatus);
        }

        // DELETE: api/EventTicketStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventTicketStatus([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eventTicketStatus = await _context.EventTicketStatuses.FindAsync(id);
            if (eventTicketStatus == null)
            {
                return NotFound();
            }

            _context.EventTicketStatuses.Remove(eventTicketStatus);
            await _context.SaveChangesAsync();

            return Ok(eventTicketStatus);
        }
        */

        private bool EventTicketStatusExists(Guid id)
        {
            return _context.EventTicketStatuses.Any(e => e.EventTicketId == id);
        }
    }
}