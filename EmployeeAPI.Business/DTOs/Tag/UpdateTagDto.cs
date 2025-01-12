using FluentValidation;

namespace EmployeeAPI.Business.DTOs.Tag;

public class UpdateTagDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}

public class UpdateTagDtoValidation : AbstractValidator<UpdateTagDto>
{
    public UpdateTagDtoValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage("Tag id is required");

        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Tag name is required")
            .MinimumLength(2)
            .WithMessage("Tag name must be at least 2 characters long");

    }
}