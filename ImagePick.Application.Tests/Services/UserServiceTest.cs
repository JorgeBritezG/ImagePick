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
        public async Task AddAsync_CreateNewUser_Ok()
        {
            //Arrange 
            var expected = UserApplicationStub.user_1;

            //Act
            var actual = await _userService.AddAsync(expected);

            //Assert
            actual.Should().BeOfType(typeof(UserApplication));
            actual.Should().NotBeNull();
            actual.Should().Equals(expected);
            actual.FirstName.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public async Task UpdateAsync_UpdateUser_Ok()
        {
            //Arrange 
            var expected = UserApplicationStub.user_1;

            //Act
            var actual = await _userService.UpdateAsync(expected);

            //Assert
            actual.Should().BeOfType(typeof(UserApplication));
            actual.Should().NotBeNull();
            actual.Should().Equals(expected);
            actual.FirstName.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public async Task DeleteAsync_ById_Ok()
        {
            //Arrange
            string id = "x";

            //Act
            var actual = await _userService.DeleteAsync(id);

            //Assert
            actual.Should().BeTrue();
        }

        [TestMethod]
        public async Task DeleteAsync_ById_InvalidId()
        {
            //Arrange 
            string id = "zzzz";

            //Act
            var actual = await _userService.DeleteAsync(id);

            //Assert
            actual.Should().BeFalse();
        }

        [TestMethod]
        public async Task GetAllAsync_ok()
        {
            //Arrange 
            var expected = UserApplicationStub.users;

            //Act
            var actual = await _userService.GetAllAsync();

            //Assert
            actual.Should().AllBeOfType(typeof(UserApplication));
            actual.Should().NotBeNull();
            actual.Should().Equals(expected);
            actual.Should().HaveCountGreaterThan(0);
        }

        [TestMethod]
        public async Task GetAsync_ById_ok()
        {
            //Arrange 
            string id = "xxx";
            var expected = UserApplicationStub.user_1;

            //Act
            var actual = await _userService.GetAsync(id);

            //Assert
            actual.Should().BeOfType(typeof(UserApplication));
            actual.Should().NotBeNull();
            actual.Should().Equals(expected);
        }

        [TestMethod]
        public async Task GetAsync_ById_InvalidId_ExpectedNulL()
        {
            //Arrange 
            string id = "zzz";

            //Act
            var actual = await _userService.GetAsync(id);

            //Assert
            actual.Should().BeNull();
        }


    }
}
