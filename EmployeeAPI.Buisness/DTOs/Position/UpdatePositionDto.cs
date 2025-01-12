﻿using FluentValidation;

namespace EmployeeAPI.Buisness.DTOs.Position;

public class UpdatePositionDto
{
    public string Name { get; set; }
}

public class UpdatePositionDtoValidator : AbstractValidator<UpdatePositionDto>
{
    public UpdatePositionDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Position name is required")
            .MinimumLength(2)
            .WithMessage("Position name must be at least 2 characters long");

    }
}