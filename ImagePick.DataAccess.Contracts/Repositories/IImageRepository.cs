using ImagePick.DataAccess.Contracts.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImagePick.DataAccess.Contracts.Repositories
{
    public interface IImageRepository
    {
        Task<IEnumerable<Image>> GetAllAsync();

        Task<IEnumerable<Image>> GetByAlbumIdAsync(int albumId);

        Task<Image> GetAsync( string id );

        Task<bool> DeleteAsync( string id );

        Task<Image> UpdateAsync( Image entity );

        Task<Image> AddAsync( Image entity );
    }
}
