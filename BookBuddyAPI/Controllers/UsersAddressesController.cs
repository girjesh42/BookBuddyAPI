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
    public class UsersAddressesController : ControllerBase
    {
        private readonly BookBuddyContext _context;

        public UsersAddressesController(BookBuddyContext context)
        {
            _context = context;
        }

        // GET: api/UsersAddresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersAddress>>> GetUsersAddress()
        {
            return await _context.UsersAddress.ToListAsync();
        }

        // GET: api/UsersAddresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsersAddress>> GetUsersAddress(int id)
        {
            var usersAddress = await _context.UsersAddress.FindAsync(id);

            if (usersAddress == null)
            {
                return NotFound();
            }

            return usersAddress;
        }

        // PUT: api/UsersAddresses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsersAddress(int id, UsersAddress usersAddress)
        {
            if (id != usersAddress.UserAddressId)
            {
                return BadRequest();
            }

            _context.Entry(usersAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersAddressExists(id))
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

        // POST: api/UsersAddresses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UsersAddress>> PostUsersAddress(UsersAddress usersAddress)
        {
            _context.UsersAddress.Add(usersAddress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsersAddress", new { id = usersAddress.UserAddressId }, usersAddress);
        }

        // DELETE: api/UsersAddresses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsersAddress>> DeleteUsersAddress(int id)
        {
            var usersAddress = await _context.UsersAddress.FindAsync(id);
            if (usersAddress == null)
            {
                return NotFound();
            }

            _context.UsersAddress.Remove(usersAddress);
            await _context.SaveChangesAsync();

            return usersAddress;
        }

        private bool UsersAddressExists(int id)
        {
            return _context.UsersAddress.Any(e => e.UserAddressId == id);
        }
    }
}
