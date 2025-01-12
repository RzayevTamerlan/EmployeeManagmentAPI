using EmployeeAPI.Buisness.DTOs.Assigment;

namespace EmployeeAPI.Buisness.DTOs.Topic;

public class GetTopicDto : BaseGetDto
{
    public string Name { get; set; }
    public List<GetAssignmentDto> Assignments { get; set; }
}