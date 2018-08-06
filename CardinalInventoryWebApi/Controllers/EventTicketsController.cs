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
    public class EventTicketsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventTicketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EventTickets
        [HttpGet]
        public IEnumerable<EventTicket> GetEventTickets()
        {
            return _context.EventTickets;
        }

        // GET: api/EventTickets/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventTicket([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eventTicket = await _context.EventTickets.FindAsync(id);

            if (eventTicket == null)
            {
                return NotFound();
            }

            return Ok(eventTicket);
        }

        // PUT: api/EventTickets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventTicket([FromRoute] Guid id, [FromBody] EventTicket eventTicket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventTicket.EventTicketId)
            {
                return BadRequest();
            }

            _context.Entry(eventTicket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventTicketExists(id))
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

        // POST: api/EventTickets
        [HttpPost]
        public async Task<IActionResult> PostEventTicket([FromBody] EventTicket eventTicket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EventTickets.Add(eventTicket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventTicket", new { id = eventTicket.EventTicketId }, eventTicket);
        }

        // DELETE: api/EventTickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventTicket([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eventTicket = await _context.EventTickets.FindAsync(id);
            if (eventTicket == null)
            {
                return NotFound();
            }

            _context.EventTickets.Remove(eventTicket);
            await _context.SaveChangesAsync();

            return Ok(eventTicket);
        }

        private bool EventTicketExists(Guid id)
        {
            return _context.EventTickets.Any(e => e.EventTicketId == id);
        }
    }
}