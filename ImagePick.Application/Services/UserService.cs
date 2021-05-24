using ImagePick.Application.Contracts.Mappers;
using ImagePick.Application.Contracts.Models;
using ImagePick.Application.Contracts.Services;
using ImagePick.DataAccess.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImagePick.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _albumRepository;

        public UserService(IUserRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public async Task<UserApplication> AddAsync( UserApplication entity )
        {
            var result = await _albumRepository.AddAsync(UserMapper.Map(entity));

            return UserMapper.Map(result);
        }

        public async Task<bool> DeleteAsync( int id )
        {
            return await _albumRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserApplication>> GetAllAsync()
        {
            var result = await _albumRepository.GetAllAsync();

            return result.Select(UserMapper.Map);
        }

        public async Task<UserApplication> GetAsync( int id )
        {
            var entity = await _albumRepository.GetAsync(id);

            return UserMapper.Map(entity);
        }

        public async Task<UserApplication> UpdateAsync( UserApplication entity )
        {
            var result = await _albumRepository.UpdateAsync(UserMapper.Map(entity));

            return UserMapper.Map(result);
        }
    }
}
