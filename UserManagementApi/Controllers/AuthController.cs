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
        var user = await _context.Users.FindAsync(login.Username);

        if (user == null)
        {
            return NotFound();
        }

        if (login.Password == user.Password)
        {
            var token = _tokenService.GenerateToken(login.Username);
            return Ok(new { Token = token });
        }

        return Unauthorized();
    }
}
