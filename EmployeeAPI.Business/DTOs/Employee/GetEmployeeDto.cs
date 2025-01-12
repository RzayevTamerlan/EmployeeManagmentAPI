namespace EmployeeAPI.Business.DTOs.Employee;

public class GetEmployeeDto : BaseGetDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string UserName { get; set; }
    public Guid DepartmentId { get; set; }
    public Guid PositionId { get; set; }
    public string PositionName { get; set; }
    public string DepartmentName { get; set; }
    public string Email { get; set; }
}