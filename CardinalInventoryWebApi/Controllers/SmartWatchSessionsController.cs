using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CardinalInventoryWebApi.Data;
using CardinalInventoryWebApi.Data.SmartWatch;

namespace CardinalInventoryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmartWatchSessionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SmartWatchSessionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SmartWatchSessions
        [HttpGet]
        public IEnumerable<SmartWatchSession> GetSmartWatchSession()
        {
            return _context.SmartWatchSessions;
        }

        // GET: api/SmartWatchSessions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSmartWatchSession([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var smartWatchSession = await _context.SmartWatchSessions.FindAsync(id);

            if (smartWatchSession == null)
            {
                return NotFound();
            }

            return Ok(smartWatchSession);
        }

        // PUT: api/SmartWatchSessions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSmartWatchSession([FromRoute] Guid id, [FromBody] SmartWatchSession smartWatchSession)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != smartWatchSession.SmartWatchSessionId)
            {
                return BadRequest();
            }

            _context.Entry(smartWatchSession).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SmartWatchSessionExists(id))
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

        // POST: api/SmartWatchSessions
        [HttpPost]
        public async Task<IActionResult> PostSmartWatchSession([FromBody] SmartWatchSession smartWatchSession)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SmartWatchSessions.Add(smartWatchSession);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSmartWatchSession", new { id = smartWatchSession.SmartWatchSessionId }, smartWatchSession);
        }

        // DELETE: api/SmartWatchSessions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSmartWatchSession([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var smartWatchSession = await _context.SmartWatchSessions.FindAsync(id);
            if (smartWatchSession == null)
            {
                return NotFound();
            }

            _context.SmartWatchSessions.Remove(smartWatchSession);
            await _context.SaveChangesAsync();

            return Ok(smartWatchSession);
        }

        private bool SmartWatchSessionExists(Guid id)
        {
            return _context.SmartWatchSessions.Any(e => e.SmartWatchSessionId == id);
        }
    }
}