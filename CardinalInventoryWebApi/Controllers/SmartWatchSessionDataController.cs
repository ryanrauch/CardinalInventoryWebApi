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
    public class SmartWatchSessionDataController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SmartWatchSessionDataController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SmartWatchSessionData
        [HttpGet]
        public IEnumerable<SmartWatchSessionData> GetSmartWatchSessionData()
        {
            return _context.SmartWatchSessionData;
        }

        // GET: api/SmartWatchSessionData/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSmartWatchSessionData([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var smartWatchSessionData = await _context.SmartWatchSessionData.FindAsync(id);

            if (smartWatchSessionData == null)
            {
                return NotFound();
            }

            return Ok(smartWatchSessionData);
        }

        // PUT: api/SmartWatchSessionData/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSmartWatchSessionData([FromRoute] int id, [FromBody] SmartWatchSessionData smartWatchSessionData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != smartWatchSessionData.Interval)
            {
                return BadRequest();
            }

            _context.Entry(smartWatchSessionData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SmartWatchSessionDataExists(id))
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

        // POST: api/SmartWatchSessionData
        [HttpPost]
        public async Task<IActionResult> PostSmartWatchSessionData([FromBody] SmartWatchSessionData smartWatchSessionData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SmartWatchSessionData.Add(smartWatchSessionData);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SmartWatchSessionDataExists(smartWatchSessionData.Interval))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSmartWatchSessionData", new { id = smartWatchSessionData.Interval }, smartWatchSessionData);
        }

        // DELETE: api/SmartWatchSessionData/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSmartWatchSessionData([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var smartWatchSessionData = await _context.SmartWatchSessionData.FindAsync(id);
            if (smartWatchSessionData == null)
            {
                return NotFound();
            }

            _context.SmartWatchSessionData.Remove(smartWatchSessionData);
            await _context.SaveChangesAsync();

            return Ok(smartWatchSessionData);
        }

        private bool SmartWatchSessionDataExists(int id)
        {
            return _context.SmartWatchSessionData.Any(e => e.Interval == id);
        }
    }
}