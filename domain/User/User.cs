namespace domain.User
{
    using System;

    /// <summary>
    ///     A class representing a User.
    /// </summary>
    public sealed record User
    {
        /// <summary>
        ///     The identifier of the user
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        ///     The first name of the user
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///     The last name of the user
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///     The date of birth of the user
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        ///     The email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     Determines if a <see cref="User" /> is eligible to apply for a mortgage based on age.
        /// </summary>
        /// <returns>Boolean representing eligibility.</returns>
        public bool IsOverEighteen()
        {
            var minimumDate = DateTime.Now.AddYears(-18);

            var result = DateTime.Compare(minimumDate, DateOfBirth) >= 1;

            return result;
        }
    }
}