namespace infrastructure
{
    using application.Product;
    using application.User;
    using Microsoft.Extensions.DependencyInjection;
    using Product;
    using Profile;
    using User;

    /// <summary>
    ///     Extensions to register infrastructure dependencies.
    /// </summary>
    public static class InfrastructureExtensions
    {
        /// <summary>
        ///     Registers infrastructure dependencies.
        /// </summary>
        /// <param name="serviceCollection">The <see cref="IServiceCollection" />.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IUserRepository, JsonUserDatastore>();
            serviceCollection.AddSingleton<IProductRepository, JsonProductDatastore>();
            serviceCollection.AddAutoMapper(typeof(MappingProfile));

            return serviceCollection;
        }
    }
}