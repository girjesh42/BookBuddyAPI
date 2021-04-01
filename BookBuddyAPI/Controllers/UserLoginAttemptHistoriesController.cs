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
    public class UserLoginAttemptHistoriesController : ControllerBase
    {
        private readonly BookBuddyContext _context;

        public UserLoginAttemptHistoriesController(BookBuddyContext context)
        {
            _context = context;
        }

        // GET: api/UserLoginAttemptHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserLoginAttemptHistory>>> GetUserLoginAttemptHistory()
        {
            return await _context.UserLoginAttemptHistory.ToListAsync();
        }

        // GET: api/UserLoginAttemptHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserLoginAttemptHistory>> GetUserLoginAttemptHistory(int id)
        {
            var userLoginAttemptHistory = await _context.UserLoginAttemptHistory.FindAsync(id);

            if (userLoginAttemptHistory == null)
            {
                return NotFound();
            }

            return userLoginAttemptHistory;
        }

        // PUT: api/UserLoginAttemptHistories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserLoginAttemptHistory(int id, UserLoginAttemptHistory userLoginAttemptHistory)
        {
            if (id != userLoginAttemptHistory.UserLoginAttemptHistoryId)
            {
                return BadRequest();
            }

            _context.Entry(userLoginAttemptHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserLoginAttemptHistoryExists(id))
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

        // POST: api/UserLoginAttemptHistories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserLoginAttemptHistory>> PostUserLoginAttemptHistory(UserLoginAttemptHistory userLoginAttemptHistory)
        {
            _context.UserLoginAttemptHistory.Add(userLoginAttemptHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserLoginAttemptHistory", new { id = userLoginAttemptHistory.UserLoginAttemptHistoryId }, userLoginAttemptHistory);
        }

        // DELETE: api/UserLoginAttemptHistories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserLoginAttemptHistory>> DeleteUserLoginAttemptHistory(int id)
        {
            var userLoginAttemptHistory = await _context.UserLoginAttemptHistory.FindAsync(id);
            if (userLoginAttemptHistory == null)
            {
                return NotFound();
            }

            _context.UserLoginAttemptHistory.Remove(userLoginAttemptHistory);
            await _context.SaveChangesAsync();

            return userLoginAttemptHistory;
        }

        private bool UserLoginAttemptHistoryExists(int id)
        {
            return _context.UserLoginAttemptHistory.Any(e => e.UserLoginAttemptHistoryId == id);
        }
    }
}
