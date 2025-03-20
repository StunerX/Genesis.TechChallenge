using FluentAssertions;
using Genesis.TechChallenge.Application.UseCases.Cdb.CalculateCdb;
using Genesis.TechChallenge.Domain.Services;
using Genesis.TechChallenge.Domain.ValueObjects;

namespace Genesis.TechChallenge.IntegrationTests.UseCases.Cdb.CalculateCdb;

public class CalculateCdbCommandHandlerTests
{
    [Theory(DisplayName = "Should calculate investment returns through command handler")]
    [InlineData(1000, 6, 1059.76, 1046.31)]
    [InlineData(1000, 12, 1123.08, 1098.47)]
    [InlineData(1000, 24, 1261.31, 1215.58)]
    [InlineData(1000, 36, 1416.56, 1354.07)]
    public async Task Handle_Should_Calculate_Investment_Returns(decimal initialAmount, int termInMonths, decimal expectedGross, decimal expectedNet)
    {
        // Arrange
        var command = new CalculateCdbCommand(initialAmount, termInMonths);

        // Act

        var calculatorService = new CdbCalculator(new CdiRate(0.009m));
        var handler = new CalculateCdbCommandHandler(calculatorService);
        var result = await handler.Handle(command, CancellationToken.None);
        
        // Assert
        result.Should().NotBeNull();
        result.GrossAmount.Should().Be(expectedGross);
        result.NetAmount.Should().Be(expectedNet);
    }
}