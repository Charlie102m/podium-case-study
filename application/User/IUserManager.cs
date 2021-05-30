namespace application.User
{
    using System.Threading;
    using System.Threading.Tasks;
    using domain.User;

    /// <summary>
    ///     An interface providing methods for managing <see cref="User" /> entities.
    /// </summary>
    public interface IUserManager
    {
        /// <summary>
        ///     Registers a new user.
        /// </summary>
        /// <param name="userDto">The user to register.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The registered <see cref="User" />.</returns>
        Task<User> RegisterUserAsync(UserDto userDto, CancellationToken cancellationToken);
    }
}