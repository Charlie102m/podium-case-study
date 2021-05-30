namespace application.User
{
    using System;

    /// <summary>
    ///     A dto representing a user for initial registration.
    /// </summary>
    public sealed record UserDto
    {
        /// <summary>
        ///     The first name of the user.
        /// </summary>
        public string FirstName { get; init; }

        /// <summary>
        ///     The last name of the user.
        /// </summary>
        public string LastName { get; init; }

        /// <summary>
        ///     The date of birth of the user.
        /// </summary>
        public DateTime DateOfBirth { get; init; }

        /// <summary>
        ///     The email of the user.
        /// </summary>
        public string Email { get; init; }
    }
}