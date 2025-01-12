using FluentValidation;

namespace EmployeeAPI.Buisness.DTOs.Department;

public class CreateDepartmentDto
{
    public string Name { get; set; }
}

public class CreateDepartmentDtoValidation : AbstractValidator<CreateDepartmentDto>
{
    public CreateDepartmentDtoValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Department name is required")
            .MinimumLength(2)
            .WithMessage("Department name must be at least 2 characters long");

    }
}