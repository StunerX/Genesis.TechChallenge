using Genesis.TechChallenge.Domain.ValueObjects;

namespace Genesis.TechChallenge.Domain.Services;

/// <summary>
/// Interface for the CDB calculator.
/// </summary>
public interface ICdbCalculator
{
    /// <summary>
    /// Calculates the CDB investment.
    /// </summary>
    /// <param name="initialAmount">The initial amount invested in the CDB.</param>
    /// <param name="period">The investment period in months.</param>
    /// <returns></returns>
    InvestmentResult Calculate(decimal initialAmount, InvestmentPeriod period);
}