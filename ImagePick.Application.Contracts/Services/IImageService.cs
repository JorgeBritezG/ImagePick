using ImagePick.Application.Contracts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImagePick.Application.Contracts.Services
{
    public interface IImageService
    {
        Task<IEnumerable<ImageApplication>> GetAllAsync();

        Task<ImageApplication> GetAsync( int id );

        Task<ImageApplication> DeleteAsync( int id );

        Task<ImageApplication> UpdateAsync( ImageApplication entity );

        Task<ImageApplication> AddAsync( ImageApplication entity );
    }
}
