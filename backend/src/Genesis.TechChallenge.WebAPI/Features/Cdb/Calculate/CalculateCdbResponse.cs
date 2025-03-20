namespace Genesis.TechChallenge.WebAPI.Features.Cdb.Calculate;

/// <summary>
/// Represents the result of a CDB investment calculation.
/// </summary>
/// <param name="GrossAmount">The total amount accrued before taxes, in BRL.</param>
/// <param name="NetAmount">The total amount after income tax deductions, in BRL.</param>
public record CalculateCdbResponse(decimal GrossAmount, decimal NetAmount);