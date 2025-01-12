using EmployeeAPI.Buisness.DTOs.Employee;

namespace EmployeeAPI.Buisness.Services.Ports;

public interface IAuthService
{
    Task<GetEmployeeDto> GetById (Guid id);
    Task<CreateEmployeeDto> RegisterAsync(CreateEmployeeDto dto);
    Task<LoginResponseDto> LoginAsync(LoginEmployeeDto dto);
    Task Update(UpdateEmployeeDto dto);
    IQueryable<GetEmployeeDto> GetAll();
    Task Delete(Guid id);
}