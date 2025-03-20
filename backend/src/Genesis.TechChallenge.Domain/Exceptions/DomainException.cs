using System.Diagnostics.CodeAnalysis;

namespace Genesis.TechChallenge.Domain.Exceptions;

/// <summary>
/// Represents an exception that occurs in the domain layer.
/// </summary>
/// <param name="message"></param>
[ExcludeFromCodeCoverage]
public class DomainException(string message) : Exception(message)
{
    
}