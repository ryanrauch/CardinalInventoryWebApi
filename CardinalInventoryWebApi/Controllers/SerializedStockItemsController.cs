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
    public class SerializedStockItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SerializedStockItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SerializedStockItems
        [HttpGet]
        public IEnumerable<SerializedStockItem> GetSerializedStockItems()
        {
            return _context.SerializedStockItems;
        }

        // GET: api/SerializedStockItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSerializedStockItem([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serializedStockItem = await _context.SerializedStockItems.FindAsync(id);

            if (serializedStockItem == null)
            {
                return NotFound();
            }

            return Ok(serializedStockItem);
        }

        // PUT: api/SerializedStockItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSerializedStockItem([FromRoute] Guid id, [FromBody] SerializedStockItem serializedStockItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serializedStockItem.SerializedStockItemId)
            {
                return BadRequest();
            }

            _context.Entry(serializedStockItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SerializedStockItemExists(id))
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

        // POST: api/SerializedStockItems
        [HttpPost]
        public async Task<IActionResult> PostSerializedStockItem([FromBody] SerializedStockItem serializedStockItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SerializedStockItems.Add(serializedStockItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSerializedStockItem", new { id = serializedStockItem.SerializedStockItemId }, serializedStockItem);
        }

        // DELETE: api/SerializedStockItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSerializedStockItem([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serializedStockItem = await _context.SerializedStockItems.FindAsync(id);
            if (serializedStockItem == null)
            {
                return NotFound();
            }

            _context.SerializedStockItems.Remove(serializedStockItem);
            await _context.SaveChangesAsync();

            return Ok(serializedStockItem);
        }

        private bool SerializedStockItemExists(Guid id)
        {
            return _context.SerializedStockItems.Any(e => e.SerializedStockItemId == id);
        }
    }
}