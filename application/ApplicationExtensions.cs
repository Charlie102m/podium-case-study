namespace application
{
    using Microsoft.Extensions.DependencyInjection;
    using Product;
    using User;

    /// <summary>
    ///     Extensions to register application dependencies.
    /// </summary>
    public static class ApplicationExtensions
    {
        /// <summary>
        ///     Registers application dependencies.
        /// </summary>
        /// <param name="serviceCollection">The <see cref="IServiceCollection" />.</param>
        /// <returns>The <see cref="IServiceCollection" /></returns>
        public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IUserManager, UserManager>();
            serviceCollection.AddSingleton<IProductManager, ProductManager>();

            return serviceCollection;
        }
    }
}