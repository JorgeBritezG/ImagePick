using ImagePick.Application.Contracts.Models;
using ImagePick.DataAccess.Contracts.Entities;
using System.Linq;

namespace ImagePick.Application.Contracts.Mappers
{
    public static class UserMapper
    {
        public static User Map(UserApplication dto)
        {
            return new User()
            {
                Id = dto.Id,
                Email = dto.Email.Trim(),
                FirstName = dto.FirstName.Trim(),
                LastName = dto.LastName.Trim(),
                UserName = dto.UserName,
                Albums = dto.Albums?.Select(AlbumMapper.Map).ToList(),

            };
        }

        public static UserApplication Map( User dto )
        {
            return new UserApplication()
            {
                Id = dto.Id,
                Email = dto.Email.Trim(),
                Name = $"{dto.FirstName.Trim()} {dto.LastName.Trim()}",
                FirstName = dto.FirstName.Trim(),
                LastName = dto.LastName.Trim(),
                UserName = dto.UserName,

            };
        }
    }
}
