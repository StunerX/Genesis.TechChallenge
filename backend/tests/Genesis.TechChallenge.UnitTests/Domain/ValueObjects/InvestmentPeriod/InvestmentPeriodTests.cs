using FluentAssertions;

namespace Genesis.TechChallenge.UnitTests.Domain.ValueObjects.InvestmentPeriod;

public class InvestmentPeriodTests
{
    [Theory(DisplayName = "Should create InvestmentPeriod when period is valid")]
    [InlineData(1)]
    [InlineData(6)]
    [InlineData(12)]
    [InlineData(24)]
    [InlineData(36)]
    public void Constructor_Should_Create_InvestmentPeriod_When_Period_Is_Valid(int validPeriod)
    {
        // Act
        var investmentPeriod = new TechChallenge.Domain.ValueObjects.InvestmentPeriod(validPeriod);

        // Assert
        investmentPeriod.Period.Should().Be(validPeriod);
    }

    [Theory(DisplayName = "Should throw exception when period is invalid")]
    [InlineData(0)]
    [InlineData(-1)]
    public void Constructor_Should_Throw_Exception_When_Period_Is_Invalid(int invalidPeriod)
    {
        // Act
        var action = () => new TechChallenge.Domain.ValueObjects.InvestmentPeriod(invalidPeriod);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("Period must be greater than 0*")
            .And.ParamName.Should().Be("Period");
    }

    [Theory(DisplayName = "Should return correct tax rate based on investment period")]
    [InlineData(1, 22.5)]
    [InlineData(6, 22.5)]
    [InlineData(7, 20)]
    [InlineData(12, 20)]
    [InlineData(13, 17.5)]
    [InlineData(24, 17.5)]
    [InlineData(25, 15)]
    [InlineData(36, 15)]
    public void GetIncomeTaxRate_Should_Return_Correct_TaxRate(int period, decimal expectedTaxRate)
    {
        // Arrange
        var investmentPeriod = new TechChallenge.Domain.ValueObjects.InvestmentPeriod(period);

        // Act
        var taxRate = investmentPeriod.GetIncomeTaxRate();

        // Assert
        taxRate.Should().Be(expectedTaxRate);
    }
}