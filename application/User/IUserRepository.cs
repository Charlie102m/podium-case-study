namespace application.User
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using domain.User;

    /// <summary>
    ///     A repository for interacting with the <see cref="User" /> datastore.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        ///     Saves a <see cref="User" /> to the data store.
        /// </summary>
        /// <param name="userDto">The user to save.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The saved <see cref="User" />.</returns>
        Task<User> SaveAsync(UserDto userDto, CancellationToken cancellationToken);

        /// <summary>
        ///     Retrieves a <see cref="User" /> by their id.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="User" />.</returns>
        Task<User> GetByIdAsync(Guid userId, CancellationToken cancellationToken);
    }
}