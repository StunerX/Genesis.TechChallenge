using Genesis.TechChallenge.Domain.Services;
using Genesis.TechChallenge.Domain.ValueObjects;
using MediatR;

namespace Genesis.TechChallenge.Application.UseCases.Cdb.CalculateCdb;

/// <summary>
///  Calculate CDB Command Handler
/// </summary>
public class CalculateCdbCommandHandler(ICdbCalculator cdbCalculator) : IRequestHandler<CalculateCdbCommand, CalculateCdbCommandResult>
{
    /// <summary>
    /// Handle the command
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<CalculateCdbCommandResult> Handle(CalculateCdbCommand command, CancellationToken cancellationToken)
    {
        var period = new InvestmentPeriod(command.Period);
        
        var investmentResult = cdbCalculator.Calculate(command.InitialAmount, period);
        return Task.FromResult(new CalculateCdbCommandResult(investmentResult.GrossAmount, investmentResult.NetAmount));
    }
}