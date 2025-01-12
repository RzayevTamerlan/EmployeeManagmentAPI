using EmployeeAPI.Business.DTOs.Department;

namespace EmployeeAPI.Business.Services.Ports;

public interface IDepartmentService
{
    Task<GetDepartmentDto> GetById (Guid id);
    Task Update(UpdateDepartmentDto dto);
    List<GetDepartmentDto> GetAll();
    Task Delete(Guid id);
    Task<GetDepartmentDto> Create(CreateDepartmentDto dto);
}