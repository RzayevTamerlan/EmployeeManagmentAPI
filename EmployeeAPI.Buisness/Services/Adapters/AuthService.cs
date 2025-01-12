using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using EmployeeAPI.Buisness.DTOs.Employee;
using EmployeeAPI.Buisness.Exceptions;
using EmployeeAPI.Buisness.Services.Ports;
using EmployeeAPI.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeAPI.Buisness.Services.Adapters;

public class AuthService : IAuthService
{
    private readonly UserManager<Employee> _userManager;
    readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    
    public AuthService(UserManager<Employee> userManager, IMapper mapper, IConfiguration configuration)
    {
        _userManager = userManager;
        _mapper = mapper;
        _configuration = configuration;
    }
    
    public async Task<GetEmployeeDto> GetById(Guid id)
    {
        var employee = await _userManager.FindByIdAsync(id.ToString());

        if (employee == null)
        {
            throw new BaseHttpException("Employee not found", 404);
        }
        
        var res = _mapper.Map<GetEmployeeDto>(employee);

        return res;
    }

    public async Task<CreateEmployeeDto> RegisterAsync(CreateEmployeeDto dto)
    {
        var isEmailUsed = await _userManager.FindByEmailAsync(dto.Email);
        var isUserNameUsed = await _userManager.FindByNameAsync(dto.UserName);

        if (isEmailUsed != null)
        {
            throw new BaseHttpException("This email is already used", 409);
        }

        if (isUserNameUsed != null)
        {
            throw new BaseHttpException("This username is already used", 409);
        }
        
        var employee = _mapper.Map<Employee>(dto);
        
        var result = await _userManager.CreateAsync(employee, dto.Password);
        
        if (!result.Succeeded)
        {
            throw new BaseHttpException("Error while creating employee", 400);
        }
        
        return _mapper.Map<CreateEmployeeDto>(employee);
    }
    
    public async Task<LoginResponseDto> LoginAsync(LoginEmployeeDto dto)
    {
        var employee = await _userManager.FindByEmailAsync(dto.Email);

        if (employee == null)
        {
            throw new BaseHttpException("Employee not found", 404);
        }

        var result = await _userManager.CheckPasswordAsync(employee, dto.Password);

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
    
    private string GenerateJwtToken(IdentityUser employee)
    {
        // Секретный ключ из конфигурации
        var secretKey = _configuration["Jwt:Secret"];
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // Устанавливаем claims
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, employee.Id),
            new Claim(JwtRegisteredClaimNames.Email, employee.Email),
            new Claim("role", "Employee"), // Добавьте роли или любые другие данные
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        // Создаем токен
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1), // Время жизни токена
            signingCredentials: creds
        );

        // Генерируем строку токена
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task Update(UpdateEmployeeDto dto)
    {
        var isEmployeeExist = await _userManager.FindByIdAsync(dto.Id.ToString());
        
        if (isEmployeeExist == null)
        {
            throw new BaseHttpException("Employee not found", 404);
        }
        
        var employee = _mapper.Map<Employee>(dto);
        
        var result = await _userManager.UpdateAsync(employee);
        
        if (!result.Succeeded)
        {
            throw new BaseHttpException("Error while updating employee", 400);
        }
    }

    public IQueryable<GetEmployeeDto> GetAll()
    {
        return _userManager.Users.Select(x => _mapper.Map<GetEmployeeDto>(x));
    }

    public async Task Delete(Guid id)
    {
        var employee = await _userManager.FindByIdAsync(id.ToString());
        
        if (employee == null)
        {
            throw new BaseHttpException("Employee not found", 404);
        }
        
        var result = await _userManager.DeleteAsync(employee);
        
        if (!result.Succeeded)
        {
            throw new BaseHttpException("Error while deleting employee", 400);
        }
    }
}