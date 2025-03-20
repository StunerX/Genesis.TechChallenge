namespace Genesis.TechChallenge.Domain.Extensions;

/// <summary>
/// Decimal extensions.
/// </summary>
public static class DecimalExtensions
{
    /// <summary>
    /// Raises a decimal value to the power of the specified exponent.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="exponent"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static decimal Pow(this decimal value, int exponent)
    {
        if (exponent < 0)
        {
            throw new ArgumentException("Exponent must be greater than or equal to 0", nameof(exponent));
        }

        decimal result = 1;
        for (var i = 0; i < exponent; i++)
        {
            result *= value;
        }

        return result;
    }
}