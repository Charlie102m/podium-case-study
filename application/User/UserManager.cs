namespace application.User
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using domain.User;

    /// <inheritdoc cref="IUserManager" />
    /// <summary>
    ///     A concrete implementation of the <see cref="IUserManager" /> interface.
    /// </summary>
    public sealed class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        ///     Initializes a new instance of the <see cref="UserManager" /> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        /// <inheritdoc />
        public async Task<User> RegisterUserAsync(UserDto userDto, CancellationToken cancellationToken)
        {
            return await _userRepository.SaveAsync(userDto, cancellationToken);
        }
    }
}