using ImagePick.Application.Contracts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImagePick.Application.Contracts.Services
{
    public interface IAlbumService
    {
        Task<IEnumerable<AlbumApplication>> GetAllAsync();

        Task<IEnumerable<AlbumApplication>> GetByUserIdAsync( string userId);

        Task<AlbumApplication> GetAsync( int id );

        Task<bool> DeleteAsync( int id );

        Task<AlbumApplication> UpdateAsync( AlbumApplication entity );

        Task<AlbumApplication> AddAsync( AlbumApplication entity );
    }
}
