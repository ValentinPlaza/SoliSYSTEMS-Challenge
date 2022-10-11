using FluentValidation;
using System.Text.RegularExpressions;
using Test.Application.Commands.Employee;

namespace Test.API.Validators;

public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        RuleFor(e => e.FullName)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(e => e.IdNumber)
            .NotEmpty()
            .MaximumLength(10);

        RuleFor(e => e.DateOfBirth)
            .NotEmpty();

        RuleFor(e => e.DateOfBirth)
            .Must(e => e <= DateTime.UtcNow)
            .WithMessage("Must not be of the future.");

        RuleFor(e => e.CompanyId)
            .NotEmpty();
    }
}