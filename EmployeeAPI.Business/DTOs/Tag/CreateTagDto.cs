using FluentValidation;

namespace EmployeeAPI.Business.DTOs.Tag;

public class CreateTagDto
{
    public string Name { get; set; }
}

public class CreateTagDtoValidation : AbstractValidator<CreateTagDto>
{
    public CreateTagDtoValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Tag name is required")
            .MinimumLength(2)
            .WithMessage("Tag name must be at least 2 characters long");

    }
}