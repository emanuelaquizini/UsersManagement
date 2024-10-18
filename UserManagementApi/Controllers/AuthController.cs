using Microsoft.AspNetCore.Mvc;
using UserManagementApi.Services;
using UserManagementApi.Models;
using Microsoft.EntityFrameworkCore;
using UserManagementApi.Data;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly TokenService _tokenService;
    private readonly AppDbContext _context;

    public AuthController(TokenService tokenService, AppDbContext context)
    {
        _tokenService = tokenService;
        _context = context;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel login)
    {
 
        if (!await _context.Users.AnyAsync(e => e.Username == login.Username))
        {
            return NotFound();
        }

        if (await _context.Users.AnyAsync(e => e.Username == login.Username && e.Password == login.Password))
        {
            var token = _tokenService.GenerateToken(login.Username);
            return Ok(new { Token = token });
        }

        return Unauthorized();
    }
}
