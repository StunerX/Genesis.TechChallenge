    namespace Genesis.TechChallenge.Domain.ValueObjects;

    /// <summary>
    /// Represents the CDI rate.
    /// </summary>
    public record CdiRate
    {
        public decimal Value { get; }

        public CdiRate(decimal percentage)
        {
            if (percentage <= 0)
            {
                throw new ArgumentException("CDI rate must be greater than 0", nameof(percentage));
            }
            
            Value = percentage;
        }
        
        /// <summary>
        /// Default CDI rate.
        /// </summary>
        public static CdiRate Default => new CdiRate(0.009m);
    }