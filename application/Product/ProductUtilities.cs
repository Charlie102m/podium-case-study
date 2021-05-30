namespace application.Product
{
    /// <summary>
    ///     A class providing utility methods for product applications.
    /// </summary>
    public static class ProductUtilities
    {
        /// <summary>
        ///     Calculates the loan to value ratio.
        /// </summary>
        /// <param name="propertyValue">The property value.</param>
        /// <param name="deposit">The deposit.</param>
        /// <returns>A decimal representation of the loan to value ratio.</returns>
        public static decimal CalculateLoanToValue(decimal propertyValue, decimal deposit)
        {
            return 1 - deposit / propertyValue;
        }
    }
}