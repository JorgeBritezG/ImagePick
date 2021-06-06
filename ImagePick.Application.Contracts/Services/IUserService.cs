using ImagePick.Application.Contracts.Models;
using ImagePick.DataAccess.Contracts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImagePick.Application.Contracts.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserApplication>> GetAllAsync();

        Task<UserApplication> GetAsync( string id );

        Task<bool> DeleteAsync( string id );

        Task<UserApplication> UpdateAsync( UserApplication entity );

        Task<UserApplication> AddAsync( UserApplication entity );

        Task<UserApplication> AuthenticateGoogleUserAsync( GoogleUserRequest request );

    }
}
