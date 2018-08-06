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
    public class EventTicketStatusHistoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventTicketStatusHistoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EventTicketStatusHistories
        [HttpGet]
        public IEnumerable<EventTicketStatusHistory> GetEventTicketStatusHistories()
        {
            return _context.EventTicketStatusHistories;
        }

        // GET: api/EventTicketStatusHistories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventTicketStatusHistory([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eventTicketStatusHistory = await _context.EventTicketStatusHistories.FindAsync(id);

            if (eventTicketStatusHistory == null)
            {
                return NotFound();
            }

            return Ok(eventTicketStatusHistory);
        }

        // PUT: api/EventTicketStatusHistories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventTicketStatusHistory([FromRoute] Guid id, [FromBody] EventTicketStatusHistory eventTicketStatusHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventTicketStatusHistory.EventTicketStatusHistoryId)
            {
                return BadRequest();
            }

            _context.Entry(eventTicketStatusHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventTicketStatusHistoryExists(id))
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

        // POST: api/EventTicketStatusHistories
        [HttpPost]
        public async Task<IActionResult> PostEventTicketStatusHistory([FromBody] EventTicketStatusHistory eventTicketStatusHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EventTicketStatusHistories.Add(eventTicketStatusHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventTicketStatusHistory", new { id = eventTicketStatusHistory.EventTicketStatusHistoryId }, eventTicketStatusHistory);
        }

        // DELETE: api/EventTicketStatusHistories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventTicketStatusHistory([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eventTicketStatusHistory = await _context.EventTicketStatusHistories.FindAsync(id);
            if (eventTicketStatusHistory == null)
            {
                return NotFound();
            }

            _context.EventTicketStatusHistories.Remove(eventTicketStatusHistory);
            await _context.SaveChangesAsync();

            return Ok(eventTicketStatusHistory);
        }

        private bool EventTicketStatusHistoryExists(Guid id)
        {
            return _context.EventTicketStatusHistories.Any(e => e.EventTicketStatusHistoryId == id);
        }
    }
}