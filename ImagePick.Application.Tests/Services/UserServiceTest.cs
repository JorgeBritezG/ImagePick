using ImagePick.Application.Contracts.Services;
using ImagePick.Application.Services;
using ImagePick.Application.Unit.Tests.MockRespository;
using ImagePick.Application.Unit.Tests.Stubs;
using ImagePick.DataAccess.Contracts.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
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
        public async Task CreateNewUser_ok()
        {
            //Arrange            
            var expected = UserStub.user_1;

            //Act



            //Assert

        }


    }
}
