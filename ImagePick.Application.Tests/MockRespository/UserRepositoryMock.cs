using ImagePick.DataAccess.Contracts.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImagePick.Application.Unit.Tests.MockRespository
{
    public class UserRepositoryMock
    {
       public Mock<IUserRepository> _userRepository { get; set; }

        public UserRepositoryMock()
        {
            _userRepository = new Mock<IUserRepository>();
        }

        private void Setup()
        {
            _userRepository.Setup
        }
    }
}
