namespace application.Product
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using domain.Product;
    using FluentResults;
    using User;

    /// <inheritdoc cref="IProductManager" />
    /// <summary>
    ///     A concrete implementation of the <see cref="IProductManager" /> class.
    /// </summary>
    public class ProductManager : IProductManager
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProductManager" /> class.
        /// </summary>
        /// <param name="productRepository">The product repository.</param>
        /// <param name="userRepository">The user repository.</param>
        public ProductManager(IProductRepository productRepository, IUserRepository userRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        /// <inheritdoc />
        public async Task<Result<IEnumerable<Product>>> SearchProductsAsync(ProductSearchDto productSearchDto,
            CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(productSearchDto.UserId, cancellationToken);

            if (user is null) return Result.Fail("The specified user does not exist.");

            if (!user.IsOverEighteen()) return Result.Fail("You are not old enough.");

            var loanToValue =
                ProductUtilities.CalculateLoanToValue(productSearchDto.PropertyValue, productSearchDto.Deposit);

            var products = await _productRepository.SearchByLtvAsync(loanToValue, cancellationToken);

            return Result.Ok(products);
        }
    }
}