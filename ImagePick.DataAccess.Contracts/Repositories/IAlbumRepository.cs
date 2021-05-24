using ImagePick.DataAccess.Contracts.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImagePick.DataAccess.Contracts.Repositories
{
    public interface IAlbumRepository
    {
        Task<IEnumerable<Album>> GetAllAsync();

        Task<Album> GetAsync( int id );

        Task<bool> DeleteAsync( int id );

        Task<Album> UpdateAsync( Album entity );

        Task<Album> AddAsync( Album entity );
    }
}
