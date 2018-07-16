using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CardinalInventoryWebApi.Data;
using CardinalInventoryWebApi.Data.Models;

namespace CardinalInventoryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryActionHistoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InventoryActionHistoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/InventoryActionHistories
        [HttpGet]
        public IEnumerable<InventoryActionHistory> GetInventoryActionHistories()
        {
            return _context.InventoryActionHistories;
        }

        // GET: api/InventoryActionHistories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInventoryActionHistory([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var inventoryActionHistory = await _context.InventoryActionHistories.FindAsync(id);

            if (inventoryActionHistory == null)
            {
                return NotFound();
            }

            return Ok(inventoryActionHistory);
        }

        // PUT: api/InventoryActionHistories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventoryActionHistory([FromRoute] Guid id, [FromBody] InventoryActionHistory inventoryActionHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inventoryActionHistory.InventoryActionHistoryId)
            {
                return BadRequest();
            }

            _context.Entry(inventoryActionHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryActionHistoryExists(id))
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

        // POST: api/InventoryActionHistories
        [HttpPost]
        public async Task<IActionResult> PostInventoryActionHistory([FromBody] InventoryActionHistory inventoryActionHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.InventoryActionHistories.Add(inventoryActionHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventoryActionHistory", new { id = inventoryActionHistory.InventoryActionHistoryId }, inventoryActionHistory);
        }

        // DELETE: api/InventoryActionHistories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventoryActionHistory([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var inventoryActionHistory = await _context.InventoryActionHistories.FindAsync(id);
            if (inventoryActionHistory == null)
            {
                return NotFound();
            }

            _context.InventoryActionHistories.Remove(inventoryActionHistory);
            await _context.SaveChangesAsync();

            return Ok(inventoryActionHistory);
        }

        private bool InventoryActionHistoryExists(Guid id)
        {
            return _context.InventoryActionHistories.Any(e => e.InventoryActionHistoryId == id);
        }
    }
}