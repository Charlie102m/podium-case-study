namespace api.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using application.Product;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    ///     A controller for querying products.
    /// </summary>
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProductController" /> class.
        /// </summary>
        /// <param name="productManager">The product manager.</param>
        public ProductController(IProductManager productManager)
        {
            _productManager = productManager ?? throw new ArgumentNullException(nameof(productManager));
        }

        /// <summary>
        ///     An endpoint for querying products.
        /// </summary>
        /// <param name="productSearchDto">The product search query.</param>
        /// <returns>A collection of products.</returns>
        [HttpGet("[controller]/search")]
        public async Task<IActionResult> SearchProducts(ProductSearchDto productSearchDto)
        {
            var result = await _productManager.SearchProductsAsync(productSearchDto, HttpContext.RequestAborted);

            if (result.IsFailed)
                return BadRequest(new ProblemDetails {Detail = result.Errors.FirstOrDefault()?.Message});

            return Ok(result.Value);
        }
    }
}