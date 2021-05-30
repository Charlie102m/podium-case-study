namespace domain.Product
{
    /// <summary>
    ///     A class representing a Product.
    /// </summary>
    public sealed record Product
    {
        /// <summary>
        ///     The name of the lender
        /// </summary>
        public string Lender { get; set; }

        /// <summary>
        ///     The interest rate expressed as a percentage.
        /// </summary>
        public decimal InterestRate { get; set; }

        /// <summary>
        ///     The type of interest calculation.
        /// </summary>
        public InterestType InterestType { get; set; }

        /// <summary>
        ///     The loan to value ratio, expressed as a percentage.
        /// </summary>
        public decimal LoanToValue { get; set; }
    }
}