using Customer.DTO;
using Customer.Services;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService service) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto model)
    {
        if (await service.IsUserExist(model))
            return Ok(new { message = "Login successful" });
        
        return Unauthorized(new { message = "Invalid email or password" });
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register(LoginDto model)
    {
        if (await service.IsEmailUsed(model))
            return BadRequest(new { message = "Email already exists" });

        await service.AddUser(model);

        return Ok(new { message = "Registration successful" });
    }
}