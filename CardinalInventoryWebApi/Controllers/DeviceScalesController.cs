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
    public class DeviceScalesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DeviceScalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DeviceScales
        [HttpGet]
        public IEnumerable<DeviceScale> GetDeviceScales()
        {
            return _context.DeviceScales;
        }

        // GET: api/DeviceScales/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeviceScale([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deviceScale = await _context.DeviceScales.FindAsync(id);

            if (deviceScale == null)
            {
                return NotFound();
            }

            return Ok(deviceScale);
        }

        // PUT: api/DeviceScales/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeviceScale([FromRoute] Guid id, [FromBody] DeviceScale deviceScale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deviceScale.DeviceScaleId)
            {
                return BadRequest();
            }

            _context.Entry(deviceScale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceScaleExists(id))
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

        // POST: api/DeviceScales
        [HttpPost]
        public async Task<IActionResult> PostDeviceScale([FromBody] DeviceScale deviceScale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DeviceScales.Add(deviceScale);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeviceScale", new { id = deviceScale.DeviceScaleId }, deviceScale);
        }

        // DELETE: api/DeviceScales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeviceScale([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deviceScale = await _context.DeviceScales.FindAsync(id);
            if (deviceScale == null)
            {
                return NotFound();
            }

            _context.DeviceScales.Remove(deviceScale);
            await _context.SaveChangesAsync();

            return Ok(deviceScale);
        }

        private bool DeviceScaleExists(Guid id)
        {
            return _context.DeviceScales.Any(e => e.DeviceScaleId == id);
        }
    }
}