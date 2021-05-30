namespace infrastructure.Product
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using application.Product;
    using domain.Product;

    /// <inheritdoc cref="IProductRepository" />
    /// <summary>
    ///     A concrete implementation of the <see cref="IProductRepository" />
    /// </summary>
    public class JsonProductDatastore : IProductRepository
    {
        /// <inheritdoc />
        public async Task<IEnumerable<Product>> SearchByLtvAsync(decimal loanToValue,
            CancellationToken cancellationToken)
        {
            var productsFromStore = await File.ReadAllTextAsync(
                Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) + "/Product/Products.json",
                cancellationToken);

            var products = JsonSerializer.Deserialize<List<Product>>(productsFromStore);

            var results = products?.Where(product => decimal.Compare(loanToValue, product.LoanToValue) == -1);

            return results;
        }
    }
}