using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Genesis.TechChallenge.WebAPI.Features.Cdb.Calculate;
using Microsoft.AspNetCore.Mvc;

namespace Genesis.TechChallenge.FunctionalTests.Cdb.CalculateCdb;

public class CalculateCdbTests(CalculateCdbTestsFixture fixture) : IClassFixture<CalculateCdbTestsFixture>
{
    private const string Endpoint = "/api/cdb/calculate";
    
    [Theory(DisplayName = "[Calculate CDB] Should return 200 OK with valid input")]
    [InlineData(1000, 6, 1059.76, 1046.31)]
    [InlineData(1000, 12, 1123.08, 1098.47)]
    [InlineData(1000, 24, 1261.31, 1215.58)]
    [InlineData(1000, 36, 1416.56, 1354.07)]
    public async Task Post_Should_ReturnOk_With_CorrectResults(
        decimal initialAmount,
        int termInMonths,
        decimal expectedGross,
        decimal expectedNet)
    {
        // Arrange
        var request = new CalculateCdbRequest(initialAmount, termInMonths);

        // Act
        var response = await fixture.ApiClient.PostAsync(Endpoint, request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var result = await response.Content.ReadFromJsonAsync<CalculateCdbResponse>();

        result.Should().NotBeNull();
        result!.GrossAmount.Should().Be(expectedGross);
        result.NetAmount.Should().Be(expectedNet);
    }
    
    [Theory(DisplayName = "[Calculate CDB] Should return 400 BadRequest with invalid input")]
    [InlineData(0, 12, "InitialAmount")]
    [InlineData(-100, 12, "InitialAmount")]
    [InlineData(1000, 0, "Period")]
    [InlineData(1000, -12, "Period")]
    public async Task Post_Should_ReturnBadRequest_When_Input_IsInvalid(
        decimal initialAmount,
        int termInMonths,
        string expectedErrorField)
    {
        // Arrange
        var request = new CalculateCdbRequest(initialAmount, termInMonths);

        // Act
        var response = await fixture.ApiClient.PostAsync(Endpoint, request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var problemDetails = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>();

        problemDetails.Should().NotBeNull();

        problemDetails!.Errors.Should().ContainKey(expectedErrorField);
    }
    
}