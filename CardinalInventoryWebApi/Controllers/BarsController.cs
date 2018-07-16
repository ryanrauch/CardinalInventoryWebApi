﻿using System;
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
    public class BarsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Bars
        [HttpGet]
        public IEnumerable<Bar> GetBars()
        {
            return _context.Bars;
        }

        // GET: api/Bars/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBar([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bar = await _context.Bars.FindAsync(id);

            if (bar == null)
            {
                return NotFound();
            }

            return Ok(bar);
        }

        // PUT: api/Bars/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBar([FromRoute] Guid id, [FromBody] Bar bar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bar.BarId)
            {
                return BadRequest();
            }

            _context.Entry(bar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarExists(id))
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

        // POST: api/Bars
        [HttpPost]
        public async Task<IActionResult> PostBar([FromBody] Bar bar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Bars.Add(bar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBar", new { id = bar.BarId }, bar);
        }

        // DELETE: api/Bars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBar([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bar = await _context.Bars.FindAsync(id);
            if (bar == null)
            {
                return NotFound();
            }

            _context.Bars.Remove(bar);
            await _context.SaveChangesAsync();

            return Ok(bar);
        }

        private bool BarExists(Guid id)
        {
            return _context.Bars.Any(e => e.BarId == id);
        }
    }
}