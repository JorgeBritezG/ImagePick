using ImagePick.Application.Contracts.Mappers;
using ImagePick.Application.Contracts.Models;
using ImagePick.Application.Contracts.Services;
using ImagePick.DataAccess.Contracts.Models;
using ImagePick.DataAccess.Contracts.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImagePick.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserApplication> AddAsync( UserApplication entity )
        {
            var result = await _userRepository.AddAsync(UserMapper.Map(entity));

            return UserMapper.Map(result);
        }        

        public async Task<bool> DeleteAsync( string id )
        {
            return await _userRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserApplication>> GetAllAsync()
        {
            var result = await _userRepository.GetAllAsync();

            return result.Select(UserMapper.Map);
        }

        public async Task<UserApplication> GetAsync( string id )
        {
            var entity = await _userRepository.GetAsync(id);

            if (entity == null )
            {
                return null;
            }

            return UserMapper.Map(entity);
        }

        public async Task<UserApplication> UpdateAsync( UserApplication entity )
        {
            var result = await _userRepository.UpdateAsync(UserMapper.Map(entity));

            return UserMapper.Map(result);
        }

        public async Task<UserApplication> AuthenticateGoogleUserAsync( GoogleUserRequest request )
        {
            var result = await _userRepository.AuthenticateGoogleUserAsync(request);

            return UserMapper.Map(result);
        }
    }
}
