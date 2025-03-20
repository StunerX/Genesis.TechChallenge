namespace Genesis.TechChallenge.Domain.ValueObjects;

/// <summary>
/// Represents the result of the CDB investment calculation, including the gross and net amounts.
/// </summary>
/// <param name="GrossAmount">The total amount obtained from the investment before income tax deduction.</param>
/// <param name="NetAmount">The final amount obtained from the investment after income tax deduction.</param>
public record InvestmentResult(decimal GrossAmount, decimal NetAmount);