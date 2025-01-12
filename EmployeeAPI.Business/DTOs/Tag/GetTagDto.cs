using EmployeeAPI.Business.DTOs.Assigment;

namespace EmployeeAPI.Business.DTOs.Tag;

public class GetTagDto : BaseGetDto
{
    public string Name { get; set; }
    public List<GetAssignmentDto> Assignments { get; set; }
}