using ImagePick.Application.Contracts.Mappers;
using ImagePick.Application.Contracts.Models;
using ImagePick.Application.Contracts.Services;
using ImagePick.DataAccess.Contracts.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImagePick.Application.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _albumRepository;

        public ImageService(IImageRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public async Task<ImageApplication> AddAsync( ImageApplication entity )
        {
            var result = await _albumRepository.AddAsync(ImageMapper.Map(entity));

            return ImageMapper.Map(result);
        }

        public async Task<bool> DeleteAsync( string id )
        {
            return await _albumRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ImageApplication>> GetAllAsync()
        {
            var result = await _albumRepository.GetAllAsync();

            return result.Select(ImageMapper.Map);
        }

        public async Task<ImageApplication> GetAsync( string id )
        {
            var entity = await _albumRepository.GetAsync(id);

            if ( entity == null )
            {
                return null;
            }

            return ImageMapper.Map(entity);
        }

        public async Task<ImageApplication> UpdateAsync( ImageApplication entity )
        {
            var result = await _albumRepository.UpdateAsync(ImageMapper.Map(entity));

            return ImageMapper.Map(result);
        }
    }
}
