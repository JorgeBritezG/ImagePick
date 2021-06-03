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
        private readonly IImageRepository _imageRepository;
        private readonly IAlbumService _albumService;

        public ImageService(
            IImageRepository imageRepository,
            IAlbumService albumService
            )
        {
            _imageRepository = imageRepository;
            _albumService = albumService;
        }

        public async Task<ImageApplication> AddAsync( ImageApplication entity )
        {
            var result = await _imageRepository.AddAsync(ImageMapper.Map(entity));

            return ImageMapper.Map(result);
        }

        public async Task<bool> DeleteAsync( string id )
        {
            return await _imageRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ImageApplication>> GetAllAsync()
        {
            var result = await _imageRepository.GetAllAsync();

            return result.Select(ImageMapper.Map);
        }

        public async Task<IEnumerable<ImageApplication>> GetByAlbumIdAsync(int imageId)
        {
            var result = await _imageRepository.GetByAlbumIdAsync(imageId);

            return result.Select(ImageMapper.Map);
        }

        public async Task<ImageApplication> GetAsync( string id )
        {
            var entity = await _imageRepository.GetAsync(id);

            if ( entity == null )
            {
                return null;
            }

            return ImageMapper.Map(entity);
        }

        public async Task<ImageApplication> GetAsync( string id, int albumId)
        {

            var album = await _albumService.GetAsync(albumId);

            if(album == null)
            {
                return null;
            }

            var entity = album.Images?.Where(x => x.Id == id).FirstOrDefault();

            if ( entity == null )
            {
                return null;
            }

            return entity;
        }

        public async Task<ImageApplication> UpdateAsync( ImageApplication entity )
        {
            var result = await _imageRepository.UpdateAsync(ImageMapper.Map(entity));

            return ImageMapper.Map(result);
        }
    }
}
