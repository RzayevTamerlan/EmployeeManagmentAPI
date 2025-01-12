namespace EmployeeAPI.Core.Entities;

public class Assignment : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public Guid TopicId { get; set; }
    public Topic Topic { get; set; }
    public List<Tag> Tags { get; set; }
    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; }
}