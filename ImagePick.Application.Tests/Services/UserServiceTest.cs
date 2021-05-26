using FluentAssertions;
using ImagePick.Application.Contracts.Models;
using ImagePick.Application.Contracts.Services;
using ImagePick.Application.Services;
using ImagePick.Application.Unit.Tests.MockRespository;
using ImagePick.Application.Unit.Tests.Stubs;
using ImagePick.DataAccess.Contracts.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace ImagePick.Application.Unit.Tests.Services
{
    [TestClass]
    public class UserServiceTest
    {
        private static IUserService _userService;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            Mock<IUserRepository> _userRepository = new UserRepositoryMock()._userRepository;

            _userService = new UserService(_userRepository.Object);
        }

        [TestMethod]
        public async Task AddAsync_CreateNewUser_ok()
        {
            //Arrange 
            var expected = UserApplicationStub.user_1;

            //Act
            var actual = await _userService.AddAsync(expected);

            //Assert
            actual.Should().BeOfType(typeof(UserApplication));
            actual.Should().NotBeNull();
            actual.Should().Equals(expected);
            actual.Id.Should().NotBe(0);
            actual.FirstName.Should().NotBeNullOrEmpty();
        }


    }
}
