using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using EmployeeAPI.Business.DTOs.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Business.Services.Adapters;

public class EmployeeService(UserManager<Employee> userManager, IMapper mapper, IHttpContextAccessor httpContextAccessor) : IEmployeeService
{
    public async Task Update(UpdateEmployeeDto dto)
    {
        var isEmployeeExist = await userManager.FindByIdAsync(dto.Id.ToString());
        
        if (isEmployeeExist == null)
        {
            throw new BaseHttpException("Employee not found", 404);
        }
        
        var employee = mapper.Map<Employee>(dto);
        
        var result = await userManager.UpdateAsync(employee);
        
        if (!result.Succeeded)
        {
            throw new BaseHttpException("Error while updating employee", 400);
        }
    }

    public List<GetEmployeeDto> GetAll(params string[] includes)
    {
        // Базовый запрос
        var employeesQuery = userManager.Users;

        // Включаем связанные данные
        if (includes is { Length: > 0 })
        {
            foreach (var include in includes)
            {
                employeesQuery = employeesQuery.Include(include);
            }
        }

        // Выполняем запрос
        var employees = employeesQuery.ToList();

        // Преобразуем список сотрудников в список DTO
        var employeeDtos = employees.Select(employee => new GetEmployeeDto
        {
            Id = Guid.Parse(employee.Id),
            Name = employee.Name,
            Surname = employee.Surname,
            UserName = employee.UserName,
            Email = employee.Email,
            PositionId = employee.PositionId ?? Guid.Empty, // Значение по умолчаниюpty, 
            PositionName = employee.Position.Name, // Навигационное свойство
            DepartmentName = employee.Department.Name // Навигационное свойство
        }).ToList();

        return employeeDtos;
    }

    public async Task Delete(Guid id)
    {
        var employee = await userManager.FindByIdAsync(id.ToString());
        
        if (employee == null)
        {
            throw new BaseHttpException("Employee not found", 404);
        }
        
        var result = await userManager.DeleteAsync(employee);
        
        if (!result.Succeeded)
        {
            throw new BaseHttpException("Error while deleting employee", 400);
        }
    }
    
    public async Task<GetEmployeeDto> GetById(Guid id, params string[] includes)
    {
        // Получаем пользователя с навигационными свойствами
        var employeeQuery = userManager.Users.Where(e => e.Id == id.ToString());

        // Включаем связанные данные
        if (includes is { Length: > 0 })
        {
            foreach (var include in includes)
            {
                employeeQuery = employeeQuery.Include(include);
            }
        }

        // Выполняем запрос
        var employee = await employeeQuery.FirstOrDefaultAsync();

        if (employee == null)
        {
            throw new BaseHttpException("Employee not found", 404);
        }

        // Создаем DTO вручную, чтобы заполнить PositionName и DepartmentName
        var employeeDto = new GetEmployeeDto
        {
            Id = Guid.Parse(employee.Id),
            Name = employee.Name,
            Surname = employee.Surname,
            UserName = employee.UserName,
            Email = employee.Email,
            PositionId = employee.PositionId ?? Guid.Empty,
            DepartmentId = employee.DepartmentId ?? Guid.Empty,
            PositionName = employee.Position.Name, // Навигационное свойство
            DepartmentName = employee.Department.Name // Навигационное свойство
        };

        return employeeDto;
    }

    public async Task<GetEmployeeDto> GetMe()
    {
        var emailClaim = httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value;
        
        if (emailClaim == null)
        {
            throw new BaseHttpException("Unauthorized", 401);
        }
        
        var employee = await userManager.Users
            .Include(e => e.Position)
            .Include(e => e.Department)
            .FirstOrDefaultAsync(e => e.Email == emailClaim);
        
        if(employee == null)
        {
            throw new BaseHttpException("Employee not found", 404);
        }
        
        return mapper.Map<GetEmployeeDto>(employee);
    }
}