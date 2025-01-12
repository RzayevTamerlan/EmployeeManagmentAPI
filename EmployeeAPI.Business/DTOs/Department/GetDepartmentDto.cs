using EmployeeAPI.Business.DTOs.Employee;

namespace EmployeeAPI.Business.DTOs.Department;

public class GetDepartmentDto : BaseGetDto
{
    public string Name { get; set; }
    public List<GetEmployeeDto> Employees { get; set; }
}