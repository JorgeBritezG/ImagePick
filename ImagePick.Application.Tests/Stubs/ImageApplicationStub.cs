using ImagePick.Application.Contracts.Models;
using System.Collections.Generic;

namespace ImagePick.Application.Unit.Tests.Stubs
{
    public static class ImageApplicationStub
    {
        
        public static ImageApplication image_null = null;

        public static ImageApplication image_1 = new ImageApplication()
        {
            Id = 1,
            AlbumId = 1,
            RegularUrl = "RegularUrl",
            SmallUrl = "SmallUrl",
            ThumbUrl = "ThumbUrl",
            UserName = "Jorge Britez",
            UserHtmlLink = "UserHtmlLink",
            UserProfileImageSmall = "UserProfileImageApplicationSmall",

        };

        public static ImageApplication image_2 = new ImageApplication()
        {
            Id = 2,
            AlbumId = 1,
            RegularUrl = "RegularUrl2",
            SmallUrl = "SmallUrl2",
            ThumbUrl = "ThumbUrl2",
            UserName = "Jorge Britez 2",
            UserHtmlLink = "UserHtmlLink2",
            UserProfileImageSmall = "UserProfileImageApplicationSmall2",

        };

        public static List<ImageApplication> images = 
            new List<ImageApplication>(new ImageApplication[] { image_1, image_2 });

    }
}
