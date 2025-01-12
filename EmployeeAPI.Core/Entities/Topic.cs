namespace EmployeeAPI.Core.Entities;

public class Topic : BaseEntity
{
    public string Name { get; set; }
    public List<Assignment> Assignments { get; set; }
}