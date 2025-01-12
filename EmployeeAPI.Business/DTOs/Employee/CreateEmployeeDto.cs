using EmployeeAPI.Business.DTOs.Department;
using FluentValidation;

namespace EmployeeAPI.Business.DTOs.Employee;

public class CreateEmployeeDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public Guid DepartmentId { get; set; }
    public Guid PositionId { get; set; }
}

public class CreateEmployeeDtoValidation : AbstractValidator<CreateEmployeeDto>
{
    public CreateEmployeeDtoValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Name is required")
            .MinimumLength(2)
            .WithMessage("Name must be at least 2 characters long");
        RuleFor(x => x.Surname)
            .NotEmpty()
            .NotNull()
            .WithMessage("Surname is required")
            .MinimumLength(2)
            .WithMessage("Surname must be at least 2 characters long");
        RuleFor(x => x.UserName)
            .NotEmpty()
            .NotNull()
            .WithMessage("Username is required")
            .MinimumLength(2)
            .WithMessage("Username must be at least 2 characters long");
        RuleFor(x => x.Password)
            .NotEmpty()
            .NotNull()
            .WithMessage("Password is required")
            .MinimumLength(6)
            .WithMessage("Password must be at least 6 characters long");
        RuleFor(x => x.Email)
            .NotEmpty()
            .NotNull()
            .WithMessage("Email is required")
            .EmailAddress()
            .WithMessage("Email is not valid");
        RuleFor(x => x.DepartmentId)
            .NotEmpty()
            .NotNull()
            .WithMessage("DepartmentId is required");
        RuleFor(x => x.PositionId)
            .NotEmpty()
            .NotNull()
            .WithMessage("PositionId is required");
    }
}