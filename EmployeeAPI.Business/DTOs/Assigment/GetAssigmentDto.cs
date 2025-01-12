using EmployeeAPI.Business.DTOs.Tag;

namespace EmployeeAPI.Business.DTOs.Assigment;

public class GetAssignmentDto : BaseGetDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public bool IsCompleted { get; set; }
    public Guid TopicId { get; set; }
    public Guid EmployeeId { get; set; }
    public string TopicName { get; set; }
    public string EmployeeFullName { get; set; }
    public List<GetTagDtoWithoutAssigments> Tags { get; set; }
}