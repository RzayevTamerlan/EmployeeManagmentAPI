using EmployeeAPI.Buisness.DTOs.Employee;

namespace EmployeeAPI.Buisness.DTOs.Department;

public class GetDepartmentDto : BaseGetDto
{
    public string Name { get; set; }
    public List<GetEmployeeDto> Employees { get; set; }
}