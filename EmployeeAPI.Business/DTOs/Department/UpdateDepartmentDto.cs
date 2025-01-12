using FluentValidation;

namespace EmployeeAPI.Business.DTOs.Department;

public class UpdateDepartmentDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<Guid> EmployeeIds { get; set; }
}

public class UpdateDepartmentDtoValidation : AbstractValidator<UpdateDepartmentDto>
{
    public UpdateDepartmentDtoValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage("Id is required");
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