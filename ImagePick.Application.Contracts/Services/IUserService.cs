using ImagePick.Application.Contracts.Models;
using ImagePick.Application.Contracts.Models.Auth;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImagePick.Application.Contracts.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserApplication>> GetAllAsync();

        Task<UserApplication> GetAsync( int id );

        Task<bool> DeleteAsync( int id );

        Task<UserApplication> UpdateAsync( UserApplication entity );

        Task<UserApplication> AddAsync( UserApplication entity );

        Task<UserApplication> AuthenticateGoogleUserAsync( GoogleUserRequest request );

    }
}
