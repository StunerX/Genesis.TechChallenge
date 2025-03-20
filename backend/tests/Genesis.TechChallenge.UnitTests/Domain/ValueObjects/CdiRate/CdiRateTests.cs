using FluentAssertions;

namespace Genesis.TechChallenge.UnitTests.Domain.ValueObjects.CdiRate;

public class CdiRateTests
{
    [Theory(DisplayName = "Should create CDI rate when percentage is valid")]
    [InlineData(0.001)]
    [InlineData(0.009)]
    [InlineData(1.5)]
    public void Constructor_Should_Create_CdiRate_When_Percentage_Is_Valid(decimal validPercentage)
    {
        // Act
        var cdiRate = new TechChallenge.Domain.ValueObjects.CdiRate(validPercentage);

        // Assert
        cdiRate.Value.Should().Be(validPercentage);
    }

    [Theory(DisplayName = "Should throw exception when percentage is invalid")]
    [InlineData(0)]
    [InlineData(-0.001)]
    public void Constructor_Should_Throw_Exception_When_Percentage_Is_Invalid(decimal invalidPercentage)
    {
        // Act
        var action = () => new TechChallenge.Domain.ValueObjects.CdiRate(invalidPercentage);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("CDI rate must be greater than 0*")
            .And.ParamName.Should().Be("percentage");
    }

    [Fact(DisplayName = "Should return default CDI rate")]
    public void Default_Should_Return_Default_CdiRate_Value()
    {
        // Act
        var defaultCdiRate = TechChallenge.Domain.ValueObjects.CdiRate.Default;

        // Assert
        defaultCdiRate.Value.Should().Be(0.009m);
    }
}