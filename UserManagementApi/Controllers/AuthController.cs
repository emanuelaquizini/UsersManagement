using Microsoft.AspNetCore.Mvc;
using UserManagementApi.Services;
using UserManagementApi.Models;


[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly TokenService _tokenService;

    public AuthController(TokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel login)
    {
        if (login.Username == "user" && login.Password == "password")
        {
            var token = _tokenService.GenerateToken(login.Username);
            return Ok(new { Token = token });
        }

        return Unauthorized();
    }
}
