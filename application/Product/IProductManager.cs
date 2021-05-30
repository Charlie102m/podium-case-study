namespace application.Product
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using domain.Product;
    using FluentResults;

    /// <summary>
    ///     An interface providing methods for interacting with <see cref="Product" /> entities.
    /// </summary>
    public interface IProductManager
    {
        /// <summary>
        ///     Queries available products by loan to value ratio.
        /// </summary>
        /// <param name="productSearchDto">The product search query.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An <see cref="IEnumerable{Product}" />.</returns>
        Task<Result<IEnumerable<Product>>> SearchProductsAsync(ProductSearchDto productSearchDto,
            CancellationToken cancellationToken);
    }
}