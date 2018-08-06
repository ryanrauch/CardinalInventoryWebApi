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
    public class EventTicketHistoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventTicketHistoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EventTicketHistories
        [HttpGet]
        public IEnumerable<EventTicketHistory> GetEventTicketHistories()
        {
            return _context.EventTicketHistories;
        }

        // GET: api/EventTicketHistories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventTicketHistory([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eventTicketHistory = await _context.EventTicketHistories.FindAsync(id);

            if (eventTicketHistory == null)
            {
                return NotFound();
            }

            return Ok(eventTicketHistory);
        }

        // PUT: api/EventTicketHistories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventTicketHistory([FromRoute] Guid id, [FromBody] EventTicketHistory eventTicketHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventTicketHistory.EventTicketHistoryId)
            {
                return BadRequest();
            }

            _context.Entry(eventTicketHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventTicketHistoryExists(id))
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

        // POST: api/EventTicketHistories
        [HttpPost]
        public async Task<IActionResult> PostEventTicketHistory([FromBody] EventTicketHistory eventTicketHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EventTicketHistories.Add(eventTicketHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventTicketHistory", new { id = eventTicketHistory.EventTicketHistoryId }, eventTicketHistory);
        }

        // DELETE: api/EventTicketHistories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventTicketHistory([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eventTicketHistory = await _context.EventTicketHistories.FindAsync(id);
            if (eventTicketHistory == null)
            {
                return NotFound();
            }

            _context.EventTicketHistories.Remove(eventTicketHistory);
            await _context.SaveChangesAsync();

            return Ok(eventTicketHistory);
        }

        private bool EventTicketHistoryExists(Guid id)
        {
            return _context.EventTicketHistories.Any(e => e.EventTicketHistoryId == id);
        }
    }
}