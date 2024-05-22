using Moq;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.Tests.Services.Tests
{
    public class UserServiceTests
    {
        [Test]
        public void RegisterShouldNotThrowException()
        {
            var mockUserRepository = new Mock<IUserRepository>();
            UserEntity nullUserEntity = null;

            mockUserRepository.Setup(m => m.Create(It.IsAny<UserEntity>())).Returns(1);
            mockUserRepository.Setup(m => m.FindByEmail(It.IsAny<string>())).Returns(nullUserEntity);

            var userService = new UserService();

            var userRegData = new UserRegistrationData();
            userRegData.FirstName = "testname";
            userRegData.LastName = "testsurname";
            userRegData.Email = "testtest@testtest.com";
            userRegData.Password = "12345678";

            Assert.DoesNotThrow(() => userService.Register(userRegData));
        }
    }
}