using FluentValidation;

namespace EmployeeAPI.Buisness.DTOs.Assigment;

public class GetAssignmentDto : BaseGetDto
{
    public string Name { get; set; }
    public Guid TopicId { get; set; }
    public Guid EmployeeId { get; set; }
    public DateTime Deadline { get; set; }
    public string Description { get; set; }
}