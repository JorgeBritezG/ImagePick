using ImagePick.Application.Contracts.Models;
using ImagePick.DataAccess.Contracts.Entities;
using System.Linq;

namespace ImagePick.Application.Contracts.Mappers
{
    public static class AlbumMapper
    {
        public static Album Map(AlbumApplication dto )
        {
            if(dto.User != null)
            {
                if(dto.User.Albums != null )
                {
                    dto.User.Albums = null;
                }
            }

            return new Album()
            {
                Id = dto.Id,
                CreatedAt = dto.CreatedAt,
                Name = dto.Name.Trim(),
                UserId = dto.UserId,
                User = dto.User == null ? null : UserMapper.Map(dto.User),
                Images = dto.Images?.Select(ImageMapper.Map).ToList(),


            };
        }

        public static AlbumApplication Map( Album dto )
        {

            if ( dto.User != null )
            {
                if ( dto.User.Albums != null )
                {
                    dto.User.Albums = null;
                }
            }

            return new AlbumApplication()
            {
                Id = dto.Id,
                CreatedAt = dto.CreatedAt,
                Name = dto.Name.Trim(),
                UserId = dto.UserId,
                User = dto.User == null ? null : UserMapper.Map(dto.User),
                Images = dto.Images?.Select(ImageMapper.Map).ToList(),

            };
        }
    }
}
