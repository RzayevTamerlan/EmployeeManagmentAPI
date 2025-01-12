namespace EmployeeAPI.Buisness.DTOs;

public class BaseGetDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}