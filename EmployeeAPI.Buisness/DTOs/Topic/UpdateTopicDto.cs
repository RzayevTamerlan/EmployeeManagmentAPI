using FluentValidation;

namespace EmployeeAPI.Buisness.DTOs.Topic;

public class UpdateTopicDto
{
    public string Name { get; set; }
}

public class UpdateTopicDtoValidation : AbstractValidator<UpdateTopicDto>
{
    public UpdateTopicDtoValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Name is required")
            .MinimumLength(2)
            .WithMessage("Name must be at least 2 characters long");
    }
}