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

        [HttpPost("create-user")]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
        }
    }
}

