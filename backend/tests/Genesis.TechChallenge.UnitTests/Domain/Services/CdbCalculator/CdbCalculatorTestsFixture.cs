using Genesis.TechChallenge.Domain.ValueObjects;

namespace Genesis.TechChallenge.UnitTests.Domain.Services.CdbCalculator;

public class CdbCalculatorTestsFixture
{
    public TechChallenge.Domain.Services.CdbCalculator GetCalculator(decimal cdiRate = 0.009m)
    {
        var rate = new CdiRate(cdiRate);
        return new TechChallenge.Domain.Services.CdbCalculator(rate);
    }

    public InvestmentPeriod GetPeriod(int months)
    {
        return new InvestmentPeriod(months);
    }
}