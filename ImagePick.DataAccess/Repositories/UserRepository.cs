using ImagePick.DataAccess.Contracts;
using ImagePick.DataAccess.Contracts.Entities;
using ImagePick.DataAccess.Contracts.Models;
using ImagePick.DataAccess.Contracts.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Google.Apis.Auth.GoogleJsonWebSignature;

namespace ImagePick.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IImagePickDbContext _imagePickDbContext;
        private readonly UserManager<User> _userManager;

        public UserRepository( 
            IImagePickDbContext imagePickDbContext,  
            UserManager<User> userManager
            )
        {
            _imagePickDbContext = imagePickDbContext;
            _userManager = userManager;
        }

        public async Task<User> AddAsync( User entity )
        {
            try
            {
               // await _imagePickDbContext.Users.AddAsync(entity);

               // await _imagePickDbContext.SaveChangesAsync();

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
                //var entity = await _imagePickDbContext.Users
                //    .FirstOrDefaultAsync(x => x.Id == id);

                //_imagePickDbContext.Users.Remove(entity);

               // await _imagePickDbContext.SaveChangesAsync();

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
                //var result = await _imagePickDbContext.Users
                //    .ToListAsync();

                // return result;
                throw new NotImplementedException();
            }
            catch ( Exception )
            {

                throw;
            }
        }

        public async Task<User> GetAsync( string id )
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
                //_imagePickDbContext.Users.Update(entity);

                //await _imagePickDbContext.SaveChangesAsync();

                return entity;

            }
            catch ( Exception )
            {

                throw;
            }


        }

        public async Task<User> AuthenticateGoogleUserAsync( GoogleUserRequest request )
        {
            Payload payload = await ValidateAsync(request.IdToken, new ValidationSettings
            {
                Audience = new[] { "442649138447-0t3eao9bnoijb3rc2rueieb4efiednm5.apps.googleusercontent.com" }
            });

            return await GetOrCreateExternalLoginUser(GoogleUserRequest.PROVIDER, payload.Subject, payload.Email, payload.GivenName, payload.FamilyName);
        }

        private async Task<User> GetOrCreateExternalLoginUser( string provider, string key, string email, string firstName, string lastName )
        {
            using ( var ctx = _userManager )
            {
                var user = await ctx.FindByLoginAsync(provider, key);
                if ( user != null )
                    return user;
                user = await ctx.FindByEmailAsync(email);
                if ( user == null )
                {
                    user = new User
                    {
                        Email = email,
                        UserName = email,
                        FirstName = firstName,
                        LastName = lastName,
                        Id = key,
                        Albums = new List<Album>()
                    {
                        new Album()
                        {
                            Id = 0,
                            CreatedAt = DateTime.UtcNow,
                            Name = "Me Gusta",
                        }
                    }
                    };
                    await ctx.CreateAsync(user);
                }

                var info = new UserLoginInfo(provider, key, provider.ToUpperInvariant());
                var result = await ctx.AddLoginAsync(user, info);
                if ( result.Succeeded )
                    return user;
                return null;

            }


        }
    }
}
