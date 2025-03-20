using FluentValidation;

namespace Genesis.TechChallenge.WebAPI.Features.Cdb.Calculate;

/// <summary>
/// Validator for the CalculateCdbRequest.
/// </summary>
public class CalculateCdbRequestValidator : AbstractValidator<CalculateCdbRequest>
{
    public CalculateCdbRequestValidator()
    {
        RuleFor(x => x.InitialAmount)
            .GreaterThan(0)
            .WithMessage("The initial amount must be greater than zero.");

        RuleFor(x => x.Period)
            .GreaterThan(0)
            .WithMessage("The term in months must be greater than zero.");
    }
}