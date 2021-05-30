namespace application.tests.Product
{
    using application.Product;
    using Xunit;

    public class ProductUtilitiesTests
    {
        public class CalculateLoanToValue
        {
            [Fact]
            public void ValidArguments_CalculateLoanToValue_ReturnsCorrectValue()
            {
                var result = ProductUtilities.CalculateLoanToValue(100, 10);

                Assert.IsType<decimal>(result);
                Assert.Equal(0.9M, result);
            }
        }
    }
}