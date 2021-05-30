namespace application.tests.Product
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using application.Product;
    using domain.Product;
    using domain.User;
    using NSubstitute;
    using User;
    using Xunit;

    public class ProductManagerTests
    {
        public class Ctor
        {
            [Fact]
            public void NullProductRepository_Ctor_ThrowsArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => new ProductManager(null, Substitute.For<IUserRepository>()));
            }
            
            [Fact]
            public void NullUserRepository_Ctor_ThrowsArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => new ProductManager(Substitute.For<IProductRepository>(),null));
            }
        }

        public class SearchProductsAsync
        {
            public SearchProductsAsync()
            {
                this.productSearchDto = new ProductSearchDto()
                {
                    UserId = new Guid(),
                    PropertyValue = 100,
                    Deposit = 40
                };
                this.userRepository = Substitute.For<IUserRepository>(); 
                this.productRepository = Substitute.For<IProductRepository>();
            }

            public IProductRepository productRepository { get; set; }

            public IUserRepository userRepository { get; set; }

            public ProductSearchDto productSearchDto { get; set; }

            [Fact]
            public async Task NullUser_SearchProductsAsync_ReturnsFailedResult()
            {
                this.userRepository.GetByIdAsync(this.productSearchDto.UserId, Arg.Any<CancellationToken>())
                    .Returns((User)null);
                
                var sut = new ProductManager(this.productRepository, this.userRepository);

                var result = await sut.SearchProductsAsync(this.productSearchDto, CancellationToken.None);
                
                Assert.True(result.IsFailed);

                await this.userRepository.Received(1)
                    .GetByIdAsync(this.productSearchDto.UserId, Arg.Any<CancellationToken>());
            }

            [Fact]
            public async Task UnderAgeUser_SearchProductsAsync_ReturnsFailedResult()
            {
                this.userRepository.GetByIdAsync(this.productSearchDto.UserId, Arg.Any<CancellationToken>())
                    .Returns(new User() { DateOfBirth = DateTime.Now.AddYears(-17) });
                
                var sut = new ProductManager(this.productRepository, this.userRepository);

                var result = await sut.SearchProductsAsync(this.productSearchDto, CancellationToken.None);
                
                Assert.True(result.IsFailed);
            }

            [Fact]
            public async Task ValidRequest_SearchProductsAsync_CorrectlyCalculatesLtv()
            {
                this.userRepository.GetByIdAsync(this.productSearchDto.UserId, Arg.Any<CancellationToken>())
                    .Returns(new User() { DateOfBirth = DateTime.Now.AddYears(-18) });

                this.productRepository.SearchByLtvAsync(Arg.Any<decimal>(), Arg.Any<CancellationToken>())
                    .Returns(new List<Product>());
                
                var sut = new ProductManager(this.productRepository, this.userRepository);

                var result = await sut.SearchProductsAsync(this.productSearchDto, CancellationToken.None);
                
                Assert.True(result.IsSuccess);
                Assert.IsAssignableFrom<IEnumerable<Product>>(result.Value);

                await this.productRepository.Received(1).SearchByLtvAsync(0.6M, Arg.Any<CancellationToken>());
            }
        }
    }
}