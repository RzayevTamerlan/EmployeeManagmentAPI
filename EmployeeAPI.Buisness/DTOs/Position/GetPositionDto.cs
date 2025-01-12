using EmployeeAPI.Buisness.DTOs.Employee;

namespace EmployeeAPI.Buisness.DTOs.Position;

public class GetPositionDto : BaseGetDto
{
    public string Name { get; set; }
    public List<GetEmployeeDto> Employees { get; set; }
}