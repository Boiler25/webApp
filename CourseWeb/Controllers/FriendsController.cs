using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CourseWeb.Models;

namespace CourseWeb.Controllers
{
    [Produces("application/json")]
    [Route("api/Friends")]
    public class FriendsController : Controller
    {
        private readonly WebAppContext _context;

        public FriendsController(WebAppContext context)
        {
            _context = context;
        }

        // GET: api/Friends
        [HttpGet]
        public IEnumerable<Friend> GetFriend()
        {
            return _context.Friend;
        }

        // GET: api/Friends/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFriend([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var friend = await _context.Friend.SingleOrDefaultAsync(m => m.Id == id);

            if (friend == null)
            {
                return NotFound();
            }

            return Ok(friend);
        }

        // PUT: api/Friends/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFriend([FromRoute] int id, [FromBody] Friend friend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != friend.Id)
            {
                return BadRequest();
            }

            _context.Entry(friend).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FriendExists(id))
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

        // POST: api/Friends
        [HttpPost]
        public async Task<IActionResult> PostFriend([FromBody] Friend friend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Friend.Add(friend);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FriendExists(friend.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFriend", new { id = friend.Id }, friend);
        }

        // DELETE: api/Friends/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFriend([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var friend = await _context.Friend.SingleOrDefaultAsync(m => m.Id == id);
            if (friend == null)
            {
                return NotFound();
            }

            _context.Friend.Remove(friend);
            await _context.SaveChangesAsync();

            return Ok(friend);
        }

        private bool FriendExists(int id)
        {
            return _context.Friend.Any(e => e.Id == id);
        }
    }
}