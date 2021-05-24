using ImagePick.DataAccess.Contracts;
using ImagePick.DataAccess.Contracts.Entities;
using ImagePick.DataAccess.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImagePick.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IImagePickDbContext _imagePickDbContext;

        public UserRepository( IImagePickDbContext imagePickDbContext )
        {
            _imagePickDbContext = imagePickDbContext;
        }

        public async Task<User> AddAsync( User entity )
        {
            try
            {
                await _imagePickDbContext.Users.AddAsync(entity);

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
                var entity = await _imagePickDbContext.Users
                    .FirstOrDefaultAsync(x => x.Id == id);

                _imagePickDbContext.Users.Remove(entity);

                await _imagePickDbContext.SaveChangesAsync();

                return true;

            }
            catch ( Exception )
            {

                return false;

                throw;
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            try
            {
                var result = await _imagePickDbContext.Users
                    .ToListAsync();

                return result;

            }
            catch ( Exception )
            {

                throw;
            }
        }

        public async Task<User> GetAsync( int id )
        {
            try
            {
                var entity = await _imagePickDbContext.Users
                    .FirstOrDefaultAsync(x => x.Id == id);

                return entity;

            }
            catch ( Exception )
            {

                throw;
            }
        }

        public async Task<User> UpdateAsync( User entity )
        {
            try
            {
                _imagePickDbContext.Users.Update(entity);

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
