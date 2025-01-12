using FluentValidation;

namespace EmployeeAPI.Buisness.DTOs.Department;

public class UpdateDepartmentDto
{
    public string Name { get; set; }
    public List<Guid> EmployeeIds { get; set; }
}

public class UpdateDepartmentDtoValidation : AbstractValidator<UpdateDepartmentDto>
{
    public UpdateDepartmentDtoValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Department name is required")
            .MinimumLength(2)
            .WithMessage("Department name must be at least 2 characters long");

        RuleFor(x => x.EmployeeIds)
            .NotNull()
            .WithMessage("EmployeeIds is required");
    }
}