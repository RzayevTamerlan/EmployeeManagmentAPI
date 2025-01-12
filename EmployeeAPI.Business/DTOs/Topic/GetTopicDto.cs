using EmployeeAPI.Business.DTOs.Assigment;

namespace EmployeeAPI.Business.DTOs.Topic;

public class GetTopicDto : BaseGetDto
{
    public string Name { get; set; }
    public List<GetAssignmentDto> Assignments { get; set; }
}