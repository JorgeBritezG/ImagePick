using ImagePick.Application.Contracts.Models;
using ImagePick.DataAccess.Contracts.Entities;

namespace ImagePick.Application.Contracts.Mappers
{
    public static class ImageMapper
    {
        public static Image Map( ImageApplication dto )
        {
            return new Image()
            {
                Id = dto.Id,
                RegularUrl = dto.RegularUrl.Trim(),
                SmallUrl = dto.SmallUrl.Trim(),
                ThumbUrl = dto.ThumbUrl.Trim(),
                UserName = dto.UserName.Trim(),
                UserProfileImageSmall = dto.UserProfileImageSmall.Trim(),
                UserHtmlLink = dto.UserHtmlLink.Trim(),
                AlbumId = dto.AlbumId, 

            };
        }

        public static ImageApplication Map( Image dto )
        {
            return new ImageApplication()
            {
                Id = dto.Id,
                RegularUrl = dto.RegularUrl.Trim(),
                SmallUrl = dto.SmallUrl.Trim(),
                ThumbUrl = dto.ThumbUrl.Trim(),
                UserName = dto.UserName.Trim(),
                UserProfileImageSmall = dto.UserProfileImageSmall.Trim(),
                UserHtmlLink = dto.UserHtmlLink.Trim(),
                AlbumId = dto.AlbumId,

            };
        }
    }
}

