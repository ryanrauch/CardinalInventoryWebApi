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
    public class InventoryHistoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InventoryHistoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/InventoryHistories
        [HttpGet]
        public IEnumerable<InventoryHistory> GetInventoryHistories()
        {
            return _context.InventoryHistories;
        }

        // GET: api/InventoryHistories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInventoryHistory([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var inventoryHistory = await _context.InventoryHistories.FindAsync(id);

            if (inventoryHistory == null)
            {
                return NotFound();
            }

            return Ok(inventoryHistory);
        }

        // PUT: api/InventoryHistories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventoryHistory([FromRoute] Guid id, [FromBody] InventoryHistory inventoryHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inventoryHistory.InventoryHistoryId)
            {
                return BadRequest();
            }

            _context.Entry(inventoryHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryHistoryExists(id))
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

        // POST: api/InventoryHistories
        [HttpPost]
        public async Task<IActionResult> PostInventoryHistory([FromBody] InventoryHistory inventoryHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.InventoryHistories.Add(inventoryHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventoryHistory", new { id = inventoryHistory.InventoryHistoryId }, inventoryHistory);
        }

        // DELETE: api/InventoryHistories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventoryHistory([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var inventoryHistory = await _context.InventoryHistories.FindAsync(id);
            if (inventoryHistory == null)
            {
                return NotFound();
            }

            _context.InventoryHistories.Remove(inventoryHistory);
            await _context.SaveChangesAsync();

            return Ok(inventoryHistory);
        }

        private bool InventoryHistoryExists(Guid id)
        {
            return _context.InventoryHistories.Any(e => e.InventoryHistoryId == id);
        }
    }
}