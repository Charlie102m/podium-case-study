namespace application.Product
{
    using System;

    /// <summary>
    ///     A dto representing a product search.
    /// </summary>
    public sealed record ProductSearchDto
    {
        /// <summary>
        ///     The total value of the property.
        /// </summary>
        public decimal PropertyValue { get; init; }

        /// <summary>
        ///     The deposit proposed by the customer.
        /// </summary>
        public decimal Deposit { get; init; }

        /// <summary>
        ///     The identifier of the user.
        /// </summary>
        public Guid UserId { get; init; }
    }
}