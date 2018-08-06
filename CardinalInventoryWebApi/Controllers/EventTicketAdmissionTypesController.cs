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
    public class EventTicketAdmissionTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventTicketAdmissionTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EventTicketAdmissionTypes
        [HttpGet]
        public IEnumerable<EventTicketAdmissionType> GetEventTicketAdmissionTypes()
        {
            return _context.EventTicketAdmissionTypes;
        }

        // GET: api/EventTicketAdmissionTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventTicketAdmissionType([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eventTicketAdmissionType = await _context.EventTicketAdmissionTypes.FindAsync(id);

            if (eventTicketAdmissionType == null)
            {
                return NotFound();
            }

            return Ok(eventTicketAdmissionType);
        }

        // PUT: api/EventTicketAdmissionTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventTicketAdmissionType([FromRoute] Guid id, [FromBody] EventTicketAdmissionType eventTicketAdmissionType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventTicketAdmissionType.EventTicketAdmissionTypeId)
            {
                return BadRequest();
            }

            _context.Entry(eventTicketAdmissionType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventTicketAdmissionTypeExists(id))
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

        // POST: api/EventTicketAdmissionTypes
        [HttpPost]
        public async Task<IActionResult> PostEventTicketAdmissionType([FromBody] EventTicketAdmissionType eventTicketAdmissionType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EventTicketAdmissionTypes.Add(eventTicketAdmissionType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventTicketAdmissionType", new { id = eventTicketAdmissionType.EventTicketAdmissionTypeId }, eventTicketAdmissionType);
        }

        // DELETE: api/EventTicketAdmissionTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventTicketAdmissionType([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eventTicketAdmissionType = await _context.EventTicketAdmissionTypes.FindAsync(id);
            if (eventTicketAdmissionType == null)
            {
                return NotFound();
            }

            _context.EventTicketAdmissionTypes.Remove(eventTicketAdmissionType);
            await _context.SaveChangesAsync();

            return Ok(eventTicketAdmissionType);
        }

        private bool EventTicketAdmissionTypeExists(Guid id)
        {
            return _context.EventTicketAdmissionTypes.Any(e => e.EventTicketAdmissionTypeId == id);
        }
    }
}