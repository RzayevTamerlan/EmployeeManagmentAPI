using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using EmployeeAPI.Business.DTOs.Employee;
using EmployeeAPI.Business.Exceptions;
using EmployeeAPI.Business.Services.Ports;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeAPI.Business.Services.Adapters;

public class AuthService(UserManager<Employee> userManager, IMapper mapper, IConfiguration configuration)
    : IAuthService
{
    public async Task<CreateEmployeeDto> RegisterAsync(CreateEmployeeDto dto)
    {
        var isEmailUsed = await userManager.FindByEmailAsync(dto.Email);
        var isUserNameUsed = await userManager.FindByNameAsync(dto.UserName);

        if (isEmailUsed != null)
        {
            throw new BaseHttpException("This email is already used", 409);
        }

        if (isUserNameUsed != null)
        {
            throw new BaseHttpException("This username is already used", 409);
        }
        
        var employee = mapper.Map<Employee>(dto);
        
        var result = await userManager.CreateAsync(employee, dto.Password);
        
        if (!result.Succeeded)
        {
            throw new BaseHttpException("Error while creating employee", 400);
        }
        
        return mapper.Map<CreateEmployeeDto>(employee);
    }
    
    public async Task<LoginResponseDto> LoginAsync(LoginEmployeeDto dto)
    {
        var employee = await userManager.FindByEmailAsync(dto.Email);

        if (employee == null)
        {
            throw new BaseHttpException("Employee not found", 404);
        }

        var result = await userManager.CheckPasswordAsync(employee, dto.Password);

        if (!result)
        {
            throw new BaseHttpException("Invalid password", 400);
        }

        // Создаем JWT токен
        var token = GenerateJwtToken(employee);

        return new LoginResponseDto()
        {
            AccessToken = token
        };
    }
    
    private string GenerateJwtToken(Employee employee)
    {
        // Секретный ключ из конфигурации
        var secretKey = configuration["JwtSettings:Secret"];
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // Устанавливаем claims
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, employee.Id),
            new Claim(JwtRegisteredClaimNames.Email, employee.Email),
            new Claim("role", "Employee"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        // Создаем токен
        var token = new JwtSecurityToken(
            issuer: configuration["JwtSettings:Issuer"],
            audience: configuration["JwtSettings:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(3), // Время жизни токена
            signingCredentials: creds
        );

        // Генерируем строку токена
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}