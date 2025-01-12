using EmployeeAPI.Business.DTOs.Employee;

namespace EmployeeAPI.Business.Services.Ports;

public interface IEmployeeService
{
    Task<GetEmployeeDto> GetById (Guid id, params string[] includes);
    Task Update(UpdateEmployeeDto dto);
    List<GetEmployeeDto> GetAll(params string[] includes);
    Task Delete(Guid id);
    Task<GetEmployeeDto> GetMe();
}