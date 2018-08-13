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
    public class PourSpoutsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PourSpoutsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PourSpouts
        [HttpGet]
        public IEnumerable<PourSpout> GetPourSpouts()
        {
            return _context.PourSpouts;
        }

        // GET: api/PourSpouts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPourSpout([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pourSpout = await _context.PourSpouts.FindAsync(id);

            if (pourSpout == null)
            {
                return NotFound();
            }

            return Ok(pourSpout);
        }

        // PUT: api/PourSpouts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPourSpout([FromRoute] Guid id, [FromBody] PourSpout pourSpout)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pourSpout.PourSpoutId)
            {
                return BadRequest();
            }

            _context.Entry(pourSpout).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PourSpoutExists(id))
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

        // POST: api/PourSpouts
        [HttpPost]
        public async Task<IActionResult> PostPourSpout([FromBody] PourSpout pourSpout)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PourSpouts.Add(pourSpout);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPourSpout", new { id = pourSpout.PourSpoutId }, pourSpout);
        }

        // DELETE: api/PourSpouts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePourSpout([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pourSpout = await _context.PourSpouts.FindAsync(id);
            if (pourSpout == null)
            {
                return NotFound();
            }

            _context.PourSpouts.Remove(pourSpout);
            await _context.SaveChangesAsync();

            return Ok(pourSpout);
        }

        private bool PourSpoutExists(Guid id)
        {
            return _context.PourSpouts.Any(e => e.PourSpoutId == id);
        }
    }
}