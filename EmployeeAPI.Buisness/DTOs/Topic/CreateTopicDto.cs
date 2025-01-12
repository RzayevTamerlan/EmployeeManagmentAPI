using FluentValidation;

namespace EmployeeAPI.Buisness.DTOs.Topic;

public class CreateTopicDto
{
    public string Name { get; set; }
}

public class CreateTopicDtoValidation : AbstractValidator<CreateTopicDto>
{
    public CreateTopicDtoValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Topic name is required")
            .MinimumLength(2)
            .WithMessage("Topic name must be at least 2 characters long");

    }
}