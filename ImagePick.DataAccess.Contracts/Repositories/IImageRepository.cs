using ImagePick.DataAccess.Contracts.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImagePick.DataAccess.Contracts.Repositories
{
    public interface IImageRepository
    {
        Task<IEnumerable<Image>> GetAllAsync();

        Task<Image> GetAsync( int id );

        Task<Image> DeleteAsync( int id );

        Task<Image> UpdateAsync( Image entity );

        Task<Image> AddAsync( Image entity );
    }
}
