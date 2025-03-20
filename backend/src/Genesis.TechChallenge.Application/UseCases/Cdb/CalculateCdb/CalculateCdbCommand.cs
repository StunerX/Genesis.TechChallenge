using MediatR;

namespace Genesis.TechChallenge.Application.UseCases.Cdb.CalculateCdb;

/// <summary>
/// Calculate CDB Command
/// </summary>
/// <param name="InitialAmount">The initial amount invested in the CDB.</param>
/// <param name="Period">The investment period in months.</param>
public record CalculateCdbCommand(decimal InitialAmount, int Period) : IRequest<CalculateCdbCommandResult>;
