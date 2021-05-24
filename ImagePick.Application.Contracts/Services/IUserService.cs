using ImagePick.Application.Contracts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImagePick.Application.Contracts.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserApplication>> GetAllAsync();

        Task<UserApplication> GetAsync( int id );

        Task<UserApplication> DeleteAsync( int id );

        Task<UserApplication> UpdateAsync( UserApplication entity );

        Task<UserApplication> AddAsync( UserApplication entity );

    }
}
