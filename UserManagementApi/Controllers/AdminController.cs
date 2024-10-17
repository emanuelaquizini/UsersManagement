using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagementApi.Data;
using UserManagementApi.Models;

namespace UserManagementApi.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("clear-database")]
        public async Task<IActionResult> ClearDatabase()
        {
            await _context.ClearDatabaseAsync();
            return Ok("Database cleared successfully.");
        }

        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var result = await _context.Users.ToListAsync();
            return result;
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            var user = await _context.GetUserByUsernameAsync(username);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("create-user")]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            if (await _context.Users.AnyAsync(u => u.Username == user.Username))
            {
                return BadRequest("Username already exists.");
            }

            if (await _context.Users.AnyAsync(u => u.Email == user.Email))
            {
                return BadRequest("Email already exists.");
            }

            _context.Users.Add(user);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "An error occurred while saving the user.");
            }

            return CreatedAtAction(nameof(GetUserByUsername), new { username = user.Username }, user);
        }
    }
}

