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
    public class EventCustomersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventCustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EventCustomers
        [HttpGet]
        public IEnumerable<EventCustomer> GetEventCustomers()
        {
            return _context.EventCustomers;
        }

        // GET: api/EventCustomers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventCustomer([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eventCustomer = await _context.EventCustomers.FindAsync(id);

            if (eventCustomer == null)
            {
                return NotFound();
            }

            return Ok(eventCustomer);
        }

        // PUT: api/EventCustomers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventCustomer([FromRoute] Guid id, [FromBody] EventCustomer eventCustomer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventCustomer.EventCustomerId)
            {
                return BadRequest();
            }

            _context.Entry(eventCustomer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventCustomerExists(id))
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

        // POST: api/EventCustomers
        [HttpPost]
        public async Task<IActionResult> PostEventCustomer([FromBody] EventCustomer eventCustomer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EventCustomers.Add(eventCustomer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventCustomer", new { id = eventCustomer.EventCustomerId }, eventCustomer);
        }

        // DELETE: api/EventCustomers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventCustomer([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eventCustomer = await _context.EventCustomers.FindAsync(id);
            if (eventCustomer == null)
            {
                return NotFound();
            }

            _context.EventCustomers.Remove(eventCustomer);
            await _context.SaveChangesAsync();

            return Ok(eventCustomer);
        }

        private bool EventCustomerExists(Guid id)
        {
            return _context.EventCustomers.Any(e => e.EventCustomerId == id);
        }
    }
}