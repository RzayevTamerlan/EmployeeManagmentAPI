using Microsoft.AspNetCore.Identity;

namespace EmployeeAPI.Core.Entities;

public class Employee : IdentityUser
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public Guid? PositionId { get; set; }
    public Position? Position { get; set; }
    public Guid? DepartmentId { get; set; }
    public Department? Department { get; set; }
    public List<Assignment> Assignments { get; set; }
}