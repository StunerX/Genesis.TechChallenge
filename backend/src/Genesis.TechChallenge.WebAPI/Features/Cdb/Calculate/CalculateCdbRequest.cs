namespace Genesis.TechChallenge.WebAPI.Features.Cdb.Calculate;

/// <summary>
/// Represents the request data for calculating a CDB investment.
/// </summary>
/// <param name="InitialAmount"></param>
/// <param name="Period"></param>
public record CalculateCdbRequest(decimal InitialAmount, int Period);
