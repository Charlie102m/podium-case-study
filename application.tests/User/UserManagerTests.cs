namespace application.tests
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using domain.User;
    using NSubstitute;
    using User;
    using Xunit;

    public sealed class UserManagerTests
    {
        public class Ctor
        {
            [Fact]
            public void NullUserRepository_Ctor_ThrowsArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => new UserManager(null));
            }
        }

        public class RegisterUserAsync
        {
            [Fact]
            public async Task ValidArguments_RegisterUserAsync_ReturnsUser()
            {
                var userRepository = Substitute.For<IUserRepository>();

                var userDto = new UserDto();

                var expectedResult = new User();

                userRepository.SaveAsync(userDto, Arg.Any<CancellationToken>()).Returns(expectedResult);

                var sut = new UserManager(userRepository);

                var result = await sut.RegisterUserAsync(userDto, CancellationToken.None);

                Assert.Equal(expectedResult, result);

                await userRepository.Received(1).SaveAsync(userDto, Arg.Any<CancellationToken>());
            }
        }
    }
}