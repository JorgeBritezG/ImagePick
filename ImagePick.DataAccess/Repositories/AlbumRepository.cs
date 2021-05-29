using ImagePick.DataAccess.Contracts;
using ImagePick.DataAccess.Contracts.Entities;
using ImagePick.DataAccess.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImagePick.DataAccess.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly IImagePickDbContext _imagePickDbContext;

        public AlbumRepository( IImagePickDbContext imagePickDbContext )
        {
            _imagePickDbContext = imagePickDbContext;
        }

        public async Task<Album> AddAsync( Album entity )
        {
            try
            {
                await _imagePickDbContext.Albums.AddAsync(entity);

                await _imagePickDbContext.SaveChangesAsync();

                return entity;

            }
            catch ( Exception )
            {

                throw;
            }
        }

        public async Task<bool> DeleteAsync( int id )
        {
            try
            {
                var entity = await _imagePickDbContext.Albums
                    .FirstOrDefaultAsync(x => x.Id == id);

                _imagePickDbContext.Albums.Remove(entity);

                await _imagePickDbContext.SaveChangesAsync();

                return true;

            }
            catch ( Exception )
            {

                return false;

                throw;
            }
        }

        public async Task<IEnumerable<Album>> GetAllAsync()
        {
            try
            {
                var result = await _imagePickDbContext.Albums
                    .ToListAsync();

                return result;

            }
            catch ( Exception )
            {

                throw;
            }
        }

        public async Task<Album> GetAsync( int id )
        {
            try
            {
                var entity = await _imagePickDbContext.Albums
                    .FirstOrDefaultAsync(x => x.Id == id);

                return entity;

            }
            catch ( Exception )
            {

                throw;
            }
        }

        public async Task<IEnumerable<Album>> GetByUserIdAsync( string userId )
        {
            try
            {
                var entity = await _imagePickDbContext.Albums
                    .Where(x => x.UserId == userId)
                    .ToListAsync();

                return entity;

            }
            catch ( Exception )
            {

                throw;
            }
        }

        public async Task<Album> UpdateAsync( Album entity )
        {
            try
            {
                _imagePickDbContext.Albums.Update(entity);

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
