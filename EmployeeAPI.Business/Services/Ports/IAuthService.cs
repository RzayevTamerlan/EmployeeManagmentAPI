using EmployeeAPI.Business.DTOs.Employee;

namespace EmployeeAPI.Business.Services.Ports;

public interface IAuthService
{
    Task<CreateEmployeeDto> RegisterAsync(CreateEmployeeDto dto);
    Task<LoginResponseDto> LoginAsync(LoginEmployeeDto dto);
}