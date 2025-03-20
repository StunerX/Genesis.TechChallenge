using FluentAssertions;
using Genesis.TechChallenge.Domain.Extensions;

namespace Genesis.TechChallenge.UnitTests.Domain.Extensions.DecimalExtensions;

public class DecimalExtensionsTests
{
    [Theory(DisplayName = "Should calculate the correct result")]
    [InlineData(2, 0, 1)]
    [InlineData(2, 1, 2)]
    [InlineData(2, 2, 4)]
    [InlineData(3, 3, 27)]
    [InlineData(5, 4, 625)]
    [InlineData(10, 2, 100)]
    [InlineData(1.5, 2, 2.25)]
    public void Pow_Should_Calculate_Correct_Result(decimal value, int exponent, decimal expected)
    {
        // Act
        var result = value.Pow(exponent);

        // Assert
        result.Should().Be(expected);
    }

    [Fact(DisplayName = "Should return one when exponent is zero")]
    public void Pow_Should_Return_One_When_Exponent_Is_Zero()
    {
        // Arrange
        var value = 10m;

        // Act
        var result = value.Pow(0);

        // Assert
        result.Should().Be(1);
    }

    [Fact(DisplayName = "Should throw ArgumentException when exponent is negative")]
    public void Pow_Should_Throw_Exception_When_Exponent_Is_Negative()
    {
        // Arrange
        var value = 2m;
        var exponent = -1;

        // Act
        var action = () => value.Pow(exponent);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("Exponent must be greater than or equal to 0*")
            .And.ParamName.Should().Be("exponent");
    }
}