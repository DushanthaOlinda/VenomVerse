using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VenomVerseApi.Models;

namespace VenomVerseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenomVerseItemsController : ControllerBase
    {
        private readonly VenomVerseContext _context;

        public VenomVerseItemsController(VenomVerseContext context)
        {
            _context = context;
        }

        // GET: api/VenomVerseItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VenomVerseItem>>> GetVenomVerseItems()
        {
            if (_context.VenomVerseItems == null)
            {
                return NotFound();
            }
            return await _context.VenomVerseItems.ToListAsync();
        }

        // GET: api/VenomVerseItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VenomVerseItem>> GetVenomVerseItem(long id)
        {
            if (_context.VenomVerseItems == null)
            {
                return NotFound();
            }
            var todoItem = await _context.VenomVerseItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        // PUT: api/VenomVerseItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenomVerseItem(long id, VenomVerseItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VenomVerseItemExists(id))
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

        // POST: api/VenomVerseItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VenomVerseItem>> PostVenomVerseItem(VenomVerseItem todoItem)
        {
            if (_context.VenomVerseItems == null)
            {
                return Problem("Entity set 'VenomVerseContext.VenomVerseItems'  is null.");
            }
            _context.VenomVerseItems.Add(todoItem);
            await _context.SaveChangesAsync();

            //    return CreatedAtAction("GetVenomVerseItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetVenomVerseItem), new { id = todoItem.Id }, todoItem);
        }

        // DELETE: api/VenomVerseItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenomVerseItem(long id)
        {
            if (_context.VenomVerseItems == null)
            {
                return NotFound();
            }
            var todoItem = await _context.VenomVerseItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _context.VenomVerseItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VenomVerseItemExists(long id)
        {
            return (_context.VenomVerseItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
