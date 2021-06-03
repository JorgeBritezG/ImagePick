using ImagePick.Application.Contracts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImagePick.Application.Contracts.Services
{
    public interface IImageService
    {
        Task<IEnumerable<ImageApplication>> GetAllAsync();

        Task<ImageApplication> GetAsync( string id );

        Task<bool> DeleteAsync( string id );

        Task<ImageApplication> UpdateAsync( ImageApplication entity );

        Task<ImageApplication> AddAsync( ImageApplication entity );
    }
}
