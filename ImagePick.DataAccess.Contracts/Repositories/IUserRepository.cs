using ImagePick.DataAccess.Contracts.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImagePick.DataAccess.Contracts.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();

        Task<User> GetAsync( int id );

        Task<User> DeleteAsync( int id );

        Task<User> UpdateAsync( User entity );

        Task<User> AddAsync( User entity );
    }
}
