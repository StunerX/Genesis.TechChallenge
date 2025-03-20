using Genesis.TechChallenge.Domain.Extensions;
using Genesis.TechChallenge.Domain.ValueObjects;

namespace Genesis.TechChallenge.Domain.Services;

/// <summary>
/// CDB calculator.
/// </summary>
public class CdbCalculator(CdiRate cdiRate) : ICdbCalculator
{
    /// <inheritdoc />
    public InvestmentResult Calculate(decimal initialAmount, InvestmentPeriod period)
    {
        if (initialAmount <= 0)
        {
            throw new ArgumentException("Initial amount must be greater than 0", nameof(initialAmount));
        }

        var bankRate = cdiRate.Value * 1.08m;
        var compoundFactor = 1m + bankRate;
        
        var grossAmount = initialAmount * compoundFactor.Pow(period.Period);
        var profit = grossAmount - initialAmount;
        
        var incomeTaxRate = period.GetIncomeTaxRate();
        var incomeTax = profit * incomeTaxRate / 100;

        var netAmount = grossAmount - incomeTax;
        
        return new InvestmentResult(Math.Round(grossAmount, 2), Math.Round(netAmount, 2));
    }
}