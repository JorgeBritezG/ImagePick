using ImagePick.Application.Unit.Tests.Stubs;
using ImagePick.DataAccess.Contracts.Entities;
using ImagePick.DataAccess.Contracts.Repositories;
using Moq;

namespace ImagePick.Application.Unit.Tests.MockRespository
{
    public class UserRepositoryMock
    {
       public Mock<IUserRepository> _userRepository { get; set; }

        public UserRepositoryMock()
        {
            _userRepository = new Mock<IUserRepository>();
            Setup();
        }

        private void Setup()
        {
            //AddAsync
            _userRepository.Setup(x => 
                x.AddAsync(It.IsAny<User>()))
                .ReturnsAsync(UserStub.user_1);

            //DeleteAsync true
            _userRepository.Setup(x =>
                x.DeleteAsync(It.Is<int>(p => p.Equals(3))))
                .ReturnsAsync(true);

            //DeleteAsync false
            _userRepository.Setup(x =>
                x.DeleteAsync(It.Is<int>(p => !p.Equals(3))))
                .ReturnsAsync(false);

            //GetAllAsync
            _userRepository.Setup(x =>
                x.GetAllAsync()).ReturnsAsync(UserStub.users);

            //GetAsync by id 1
            _userRepository.Setup(x =>
                x.GetAsync(It.Is<int>(p => p.Equals(1))))
                .ReturnsAsync(UserStub.user_1);

            //GetAsync by not id 1
            _userRepository.Setup(x =>
                x.GetAsync(It.Is<int>(p => !p.Equals(1))))
                .ReturnsAsync(UserStub.user_null);

            //UpdateAsync
            _userRepository.Setup(x =>
                x.UpdateAsync(It.IsAny<User>()))
                .ReturnsAsync(UserStub.user_1);
        }
    }
}
