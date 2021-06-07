using ImagePick.DataAccess.Contracts.Entities;
using System.Collections.Generic;

namespace ImagePick.Application.Unit.Tests.Stubs
{
    public static class ImageStub
    {
        
        public static Image image_null = null;

        public static Image image_1 = new Image()
        {
            Id = "xxx",
            AlbumId = 1,
            RegularUrl = "RegularUrl",
            SmallUrl = "SmallUrl",
            ThumbUrl = "ThumbUrl",
            UserName = "Jorge Britez",
            UserHtmlLink = "UserHtmlLink",
            UserProfileImageSmall = "UserProfileImageSmall",

        };

        public static Image image_2 = new Image()
        {
            Id = "yyy",
            AlbumId = 1,
            RegularUrl = "RegularUrl2",
            SmallUrl = "SmallUrl2",
            ThumbUrl = "ThumbUrl2",
            UserName = "Jorge Britez 2",
            UserHtmlLink = "UserHtmlLink2",
            UserProfileImageSmall = "UserProfileImageSmall2",

        };

        public static List<Image> images = 
            new List<Image>(new Image[] { image_1, image_2 });

    }
}
