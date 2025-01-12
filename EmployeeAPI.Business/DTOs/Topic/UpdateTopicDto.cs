using FluentValidation;

namespace EmployeeAPI.Business.DTOs.Topic;

public class UpdateTopicDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}

public class UpdateTopicDtoValidation : AbstractValidator<UpdateTopicDto>
{
    public UpdateTopicDtoValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage("Id is required");
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Name is required")
            .MinimumLength(2)
            .WithMessage("Name must be at least 2 characters long");
    }
}