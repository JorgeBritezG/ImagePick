using ImagePick.DataAccess.Contracts.Entities;
using ImagePick.DataAccess.Contracts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImagePick.DataAccess.Contracts.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();

        Task<User> GetAsync( string id );

        Task<bool> DeleteAsync( string id );

        Task<User> UpdateAsync( User entity );

        Task<User> AddAsync( User entity );

        Task<User> AuthenticateGoogleUserAsync( GoogleUserRequest request );
    }
}
