using Customer.API;
using Customer.Services;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController(IUserService userService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Registration([FromBody] UserRequestData requestData)
    {
        if (requestData == null)
            return BadRequest(new { message = "Data is required." });

        var result = await userService.TryRegistration(requestData);
        
        if (result)
        {
            return Ok(new
            {
                message = "Registration completed.",
                data = requestData
            });
        }

        return BadRequest(new { message = "Registration failed." });
    }
    
    [HttpGet]
    public async Task<IActionResult> Login([FromBody] UserRequestData requestData)
    {
        if (requestData == null)
            return BadRequest(new { message = "Data is required." });

        var result = await userService.Login(requestData);
        
        if (result)
        {
            return Ok(new
            {
                message = "Login Successful.",
                data = requestData
            });
        }

        return BadRequest(new { message = "login failed." });
    }
}