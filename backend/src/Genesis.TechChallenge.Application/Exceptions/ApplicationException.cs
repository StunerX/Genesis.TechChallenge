using System.Diagnostics.CodeAnalysis;

namespace Genesis.TechChallenge.Application.Exceptions;

/// <summary>
/// Represents an exception that occurs in the application layer.
/// </summary>
/// <param name="message"></param>
[ExcludeFromCodeCoverage]
public class ApplicationException(string message) : Exception(message)
{
    
}