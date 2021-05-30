namespace application.Product
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using domain.Product;

    /// <summary>
    ///     A repository for interacting with the <see cref="Product" /> datastore.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        ///     Retrieves a collection of <see cref="Product" /> from the datastore based on LTV suitability.
        /// </summary>
        /// <param name="loanToValue">The loan to value ratio.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An <see cref="IEnumerable{Product}" /></returns>
        Task<IEnumerable<Product>> SearchByLtvAsync(decimal loanToValue, CancellationToken cancellationToken);
    }
}