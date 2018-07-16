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
    public class StockItemCategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StockItemCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/StockItemCategories
        [HttpGet]
        public IEnumerable<StockItemCategory> GetStockItemCategories()
        {
            return _context.StockItemCategories;
        }

        // GET: api/StockItemCategories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStockItemCategory([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stockItemCategory = await _context.StockItemCategories.FindAsync(id);

            if (stockItemCategory == null)
            {
                return NotFound();
            }

            return Ok(stockItemCategory);
        }

        // PUT: api/StockItemCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStockItemCategory([FromRoute] Guid id, [FromBody] StockItemCategory stockItemCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stockItemCategory.StockItemCategoryId)
            {
                return BadRequest();
            }

            _context.Entry(stockItemCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockItemCategoryExists(id))
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

        // POST: api/StockItemCategories
        [HttpPost]
        public async Task<IActionResult> PostStockItemCategory([FromBody] StockItemCategory stockItemCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.StockItemCategories.Add(stockItemCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStockItemCategory", new { id = stockItemCategory.StockItemCategoryId }, stockItemCategory);
        }

        // DELETE: api/StockItemCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStockItemCategory([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stockItemCategory = await _context.StockItemCategories.FindAsync(id);
            if (stockItemCategory == null)
            {
                return NotFound();
            }

            _context.StockItemCategories.Remove(stockItemCategory);
            await _context.SaveChangesAsync();

            return Ok(stockItemCategory);
        }

        private bool StockItemCategoryExists(Guid id)
        {
            return _context.StockItemCategories.Any(e => e.StockItemCategoryId == id);
        }
    }
}