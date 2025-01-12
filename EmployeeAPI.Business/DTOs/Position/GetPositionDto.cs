using EmployeeAPI.Business.DTOs.Employee;

namespace EmployeeAPI.Business.DTOs.Position;

public class GetPositionDto : BaseGetDto
{
    public string Name { get; set; }
    public List<GetEmployeeDto> Employees { get; set; }
}