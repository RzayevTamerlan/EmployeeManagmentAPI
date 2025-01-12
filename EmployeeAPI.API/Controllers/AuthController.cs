using EmployeeAPI.Buisness.DTOs.Employee;
using EmployeeAPI.Buisness.Services.Ports;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        this._authService = authService;
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginEmployeeDto loginDto)
    {
        var result = await _authService.LoginAsync(loginDto);
        return Ok(result);
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreateEmployeeDto registerDto)
    {
        var result = await _authService.RegisterAsync(registerDto);
        return Ok(result);
    }
}

// dotnet ef migrations add Init --project EmployeeAPI.DAL --startup-project EmployeeAPI