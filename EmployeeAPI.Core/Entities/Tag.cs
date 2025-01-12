namespace EmployeeAPI.Core.Entities;

public class Tag : BaseEntity
{
    public string Name { get; set; }
    public List<Assignment> Assignments { get; set; }
}