namespace EmployeeAPI.Buisness.DTOs.Employee;

public class GetEmployeeDto : BaseGetDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string UserName { get; set; }
    public Guid DepartmentId { get; set; }
    public Guid PositionId { get; set; }
    public string Email { get; set; }
}