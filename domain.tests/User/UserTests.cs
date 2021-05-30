namespace domain.tests.User
{
    using System;
    using domain.User;
    using Xunit;

    public sealed class UserTests
    {
        public class Ctor
        {
            [Fact]
            public void Ctor_GetSetProperties()
            {
                var testDate = DateTime.Now;

                var sut = new User
                {
                    UserId = Guid.Empty,
                    Email = "test@abc.com",
                    FirstName = "Podium",
                    LastName = "Test",
                    DateOfBirth = testDate
                };

                Assert.IsType<User>(sut);
                Assert.Equal(Guid.Empty, sut.UserId);
                Assert.Equal("test@abc.com", sut.Email);
                Assert.Equal("Podium", sut.FirstName);
                Assert.Equal("Test", sut.LastName);
                Assert.Equal(testDate, sut.DateOfBirth);
            }
        }
    }
}