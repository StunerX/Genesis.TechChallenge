using FluentAssertions;

namespace Genesis.TechChallenge.UnitTests.Domain.Services.CdbCalculator;

public class CdbCalculatorTests(CdbCalculatorTestsFixture fixture) : IClassFixture<CdbCalculatorTestsFixture>
{
    [Theory(DisplayName = "Should calculate gross and net amounts correctly based on initial amount and term")]
    [InlineData(1000, 6, 1059.76, 1046.31)]
    [InlineData(1000, 12, 1123.08, 1098.47)]
    [InlineData(1000, 24, 1261.31, 1215.58)]
    [InlineData(1000, 36, 1416.56, 1354.07)]
    public void Calculate_Should_Return_Expected_Results(decimal initialAmount, int termInMonths, decimal expectedGross, decimal expectedNet)
    {
        // Arrange
        var calculator = fixture.GetCalculator();
        var period = fixture.GetPeriod(termInMonths);

        // Act
        var result = calculator.Calculate(initialAmount, period);

        // Assert
        result.GrossAmount.Should().Be(expectedGross);
        result.NetAmount.Should().Be(expectedNet);
    }
    
    [Fact(DisplayName = "Should throw ArgumentException when initial amount is zero")]
    public void Calculate_Should_Throw_When_InitialAmount_Is_Zero()
    {
        // Arrange
        var calculator = fixture.GetCalculator();
        var period = fixture.GetPeriod(12);

        // Act
        Action action = () => calculator.Calculate(0, period);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("Initial amount must be greater than 0*");
    }
    
    [Fact(DisplayName = "Should throw ArgumentException when initial amount is negative")]
    public void Calculate_Should_Throw_When_InitialAmount_Is_Negative()
    {
        // Arrange
        var calculator = fixture.GetCalculator();
        var period = fixture.GetPeriod(12);

        // Act
        Action action = () => calculator.Calculate(-1000, period);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("Initial amount must be greater than 0*");
    }

    [Theory(DisplayName = "Should throw ArgumentException when investment period is invalid")]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    public void InvestmentPeriod_Should_Throw_When_Period_Less_Than_One(int period)
    {
        // Act
        Action action = () => fixture.GetPeriod(0);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("Period must be greater than 1*");
    }
}