using ImagePick.DataAccess.Contracts;
using ImagePick.DataAccess.Contracts.Entities;
using ImagePick.DataAccess.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImagePick.DataAccess.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly IImagePickDbContext _imagePickDbContext;

        public ImageRepository( IImagePickDbContext imagePickDbContext )
        {
            _imagePickDbContext = imagePickDbContext;
        }

        public async Task<Image> AddAsync( Image entity )
        {
            try
            {
                await _imagePickDbContext.Images.AddAsync(entity);

                await _imagePickDbContext.SaveChangesAsync();

                return entity;

            }
            catch ( Exception )
            {

                throw;
            }
        }

        public async Task<bool> DeleteAsync( string id )
        {
            try
            {
                var entity = await _imagePickDbContext.Images
                    .FirstOrDefaultAsync(x => x.Id == id);

                _imagePickDbContext.Images.Remove(entity);

                await _imagePickDbContext.SaveChangesAsync();

                return true;

            }
            catch ( Exception )
            {

                return false;

                throw;
            }
        }

        public async Task<IEnumerable<Image>> GetAllAsync()
        {
            try
            {
                var result = await _imagePickDbContext.Images
                    .ToListAsync();

                return result;

            }
            catch ( Exception )
            {

                throw;
            }
        }

        public async Task<Image> GetAsync( string id )
        {
            try
            {
                var entity = await _imagePickDbContext.Images
                    .FirstOrDefaultAsync(x => x.Id == id);

                return entity;

            }
            catch ( Exception )
            {

                throw;
            }
        }

        public async Task<Image> UpdateAsync( Image entity )
        {
            try
            {
                _imagePickDbContext.Images.Update(entity);

                await _imagePickDbContext.SaveChangesAsync();

                return entity;

            }
            catch ( Exception )
            {

                throw;
            }


        }
    }
}
