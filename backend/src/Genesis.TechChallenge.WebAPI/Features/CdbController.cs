using Genesis.TechChallenge.Application.UseCases.Cdb.CalculateCdb;
using Genesis.TechChallenge.WebAPI.Features.Cdb.Calculate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Genesis.TechChallenge.WebAPI.Features;

/// <summary>
/// Controller for calculating CDB
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class CdbController(IMediator mediator, ILogger<CdbController> logger) : ControllerBase
{
    /// <summary>
    /// Calculates the CDB investment return based on initial amount and term.
    /// </summary>
    /// <param name="request">The investment calculation request data.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>The gross and net investment results.</returns>
    [HttpPost("calculate")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> CalculateCdb([FromBody] CalculateCdbRequest request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Calculating CDB");
        var command = new CalculateCdbCommand(request.InitialAmount, request.Period);
        var result = await mediator.Send(command, cancellationToken);
        var response = new CalculateCdbResponse(result.GrossAmount, result.NetAmount);
        logger.LogInformation("CDB Calculated");
        return Ok(response);
    }
}