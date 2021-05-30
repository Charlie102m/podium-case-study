namespace infrastructure.User
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Text.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using application.User;
    using AutoMapper;
    using domain.User;

    /// <inheritdoc cref="IUserRepository" />
    /// <summary>
    ///     A concrete implementation of the <see cref="IUserRepository" />
    /// </summary>
    public sealed class JsonUserDatastore : IUserRepository
    {
        private readonly IMapper _mapper;

        public JsonUserDatastore(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <inheritdoc />
        public async Task<User> SaveAsync(UserDto userDto, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(userDto);

            user.UserId = Guid.NewGuid();

            var usersFromStore = await File.ReadAllTextAsync(
                Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) + "/User/Users.json", cancellationToken);

            var existingUsers = JsonSerializer.Deserialize<List<User>>(usersFromStore);

            existingUsers?.Add(user);

            var usersToSave = JsonSerializer.Serialize(existingUsers);

            await File.WriteAllTextAsync(
                Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) + "/User/Users.json", usersToSave,
                cancellationToken);

            return user;
        }

        /// <inheritdoc />
        public async Task<User> GetByIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            var usersFromStore = await File.ReadAllTextAsync(
                Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) + "/User/Users.json", cancellationToken);

            var users = JsonSerializer.Deserialize<List<User>>(usersFromStore);

            return users?.Find(user => user.UserId == userId);
        }
    }
}