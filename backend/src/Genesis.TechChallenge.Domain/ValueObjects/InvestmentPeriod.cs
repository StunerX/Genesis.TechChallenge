namespace Genesis.TechChallenge.Domain.ValueObjects;

/// <summary>
/// Represents the investment period in months.
/// </summary>
public record InvestmentPeriod
{
    public int Period { get; }

    public InvestmentPeriod(int Period)
    {
        if (Period <= 0)
        {
            throw new ArgumentException("Period must be greater than 0", nameof(Period));
        }
        
        this.Period = Period;
    }
    
    /// <summary>
    /// Get the income tax rate based on the investment period.
    /// </summary>
    /// <returns></returns>
    public decimal GetIncomeTaxRate()
    {
        return Period switch
        {
            <= 6 => 22.5m,
            <= 12 => 20m,
            <= 24 => 17.5m,
            _ => 15m
        };
    }
}