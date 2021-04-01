using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookBuddyAPI.Models;

namespace BookBuddyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTagsController : ControllerBase
    {
        private readonly BookBuddyContext _context;

        public ProductTagsController(BookBuddyContext context)
        {
            _context = context;
        }

        // GET: api/ProductTags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductTag>>> GetProductTag()
        {
            return await _context.ProductTag.ToListAsync();
        }

        // GET: api/ProductTags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductTag>> GetProductTag(int id)
        {
            var productTag = await _context.ProductTag.FindAsync(id);

            if (productTag == null)
            {
                return NotFound();
            }

            return productTag;
        }

        // PUT: api/ProductTags/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductTag(int id, ProductTag productTag)
        {
            if (id != productTag.ProductTagId)
            {
                return BadRequest();
            }

            _context.Entry(productTag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductTagExists(id))
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

        // POST: api/ProductTags
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductTag>> PostProductTag(ProductTag productTag)
        {
            _context.ProductTag.Add(productTag);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductTag", new { id = productTag.ProductTagId }, productTag);
        }

        // DELETE: api/ProductTags/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductTag>> DeleteProductTag(int id)
        {
            var productTag = await _context.ProductTag.FindAsync(id);
            if (productTag == null)
            {
                return NotFound();
            }

            _context.ProductTag.Remove(productTag);
            await _context.SaveChangesAsync();

            return productTag;
        }

        private bool ProductTagExists(int id)
        {
            return _context.ProductTag.Any(e => e.ProductTagId == id);
        }
    }
}
