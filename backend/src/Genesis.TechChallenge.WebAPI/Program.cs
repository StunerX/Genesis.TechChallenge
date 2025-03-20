using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using FluentValidation.AspNetCore;
using Genesis.TechChallenge.Application.DependecyInjection;
using Genesis.TechChallenge.Infrastructure.DependencyInjection;
using Genesis.TechChallenge.Infrastructure.Logging;
using Genesis.TechChallenge.WebAPI.Features.Cdb.Calculate;
using Genesis.TechChallenge.WebAPI.Middlewares;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//Serilog

builder.Services.AddInfrastructureModule(builder.Configuration);


builder.Host.UseSerilog();

if (!builder.Environment.IsEnvironment("Testing"))
{
    builder.Services.AddSerilogModule(builder.Configuration);

    builder.Services.AddAllElasticApm();
}

builder.Services.AddValidatorsFromAssemblyContaining<CalculateCdbRequestValidator>();
builder.Services.AddFluentValidationAutoValidation();
// Add services to the container.
builder.Services.AddApplicationModule();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularFrontend",
        policy => policy
            .WithOrigins("http://localhost:4200") // libera o Angular local
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAngularFrontend");

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

[ExcludeFromCodeCoverage]
public abstract partial class Program;