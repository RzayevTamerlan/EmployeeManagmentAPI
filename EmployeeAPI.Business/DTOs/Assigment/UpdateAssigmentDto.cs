using FluentValidation;

namespace EmployeeAPI.Business.DTOs.Assigment;

public class UpdateAssigmentDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime Deadline { get; set; }
    public Guid TopicId { get; set; }
    public Guid EmployeeId { get; set; }
}

public class UpdateAssigmentDtoValidator : AbstractValidator<UpdateAssigmentDto>
{
    public UpdateAssigmentDtoValidator()
    {
        RuleFor(x => x.IsCompleted)
            .NotNull()
            .NotEmpty()
            .WithMessage("IsCompleted is required");
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .MinimumLength(2)
            .WithMessage("Name must be at least 2 characters long");
        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is required")
            .MinimumLength(2)
            .WithMessage("Description must be at least 2 characters long");
        RuleFor(x => x.Deadline)
            .NotEmpty()
            .WithMessage("Deadline is required")
            .GreaterThan(DateTime.Now)
            .WithMessage("Deadline must be greater than current date");
        RuleFor(x => x.TopicId)
            .NotEmpty()
            .WithMessage("TopicId is required");
        RuleFor(x => x.EmployeeId)
            .NotEmpty()
            .WithMessage("EmployeeId is required");
    }
}
