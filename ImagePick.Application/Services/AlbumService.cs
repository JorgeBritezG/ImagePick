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
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public async Task<AlbumApplication> AddAsync( AlbumApplication entity )
        {
            var result = await _albumRepository.AddAsync(AlbumMapper.Map(entity));

            return AlbumMapper.Map(result);
        }

        public async Task<bool> DeleteAsync( int id )
        {
            return await _albumRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<AlbumApplication>> GetAllAsync()
        {
            var result = await _albumRepository.GetAllAsync();

            return result.Select(AlbumMapper.Map);
        }

        public async Task<AlbumApplication> GetAsync( int id )
        {
            var entity = await _albumRepository.GetAsync(id);

            return AlbumMapper.Map(entity);
        }

        public async Task<AlbumApplication> UpdateAsync( AlbumApplication entity )
        {
            var result = await _albumRepository.UpdateAsync(AlbumMapper.Map(entity));

            return AlbumMapper.Map(result);
        }
    }
}
