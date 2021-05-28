using ImagePick.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;

namespace ImagePick.Application.Unit.Tests.Stubs
{
    public static class AlbumStub
    {
        
        public static Album album_null = null;

        public static Album album_1 = new Album()
        {
            Id = 1,
            CreatedAt = DateTime.Now,
            Name = "Me Gusta",
            UserId = "",
            Images = new List<Image>()
            {
                new Image() 
                {
                    Id = 1,
                    AlbumId = 1,
                    RegularUrl = "RegularUrl",
                    SmallUrl = "SmallUrl",
                    ThumbUrl = "ThumbUrl",
                    UserName = "Jorge Britez",
                    UserHtmlLink = "UserHtmlLink",
                    UserProfileImageSmall = "UserProfileImageSmall"
                },
                new Image()
                {
                    Id = 2,
                    AlbumId = 1,
                    RegularUrl = "RegularUrl2",
                    SmallUrl = "SmallUrl2",
                    ThumbUrl = "ThumbUrl2",
                    UserName = "Jorge Britez 2",
                    UserHtmlLink = "UserHtmlLink2",
                    UserProfileImageSmall = "UserProfileImageSmall2"
                }
            }
        };

        public static Album album_2 = new Album()
        {
            Id = 1,
            CreatedAt = DateTime.Now,
            Name = "Favoritos",
            UserId = "",
            Images = new List<Image>()
            {
                new Image()
                {
                    Id = 3,
                    AlbumId = 2,
                    RegularUrl = "RegularUrl3",
                    SmallUrl = "SmallUrl3",
                    ThumbUrl = "ThumbUrl3",
                    UserName = "Jorge Britez 3",
                    UserHtmlLink = "UserHtmlLink3",
                    UserProfileImageSmall = "UserProfileImageSmall3"
                },
                new Image()
                {
                    Id = 4,
                    AlbumId = 2,
                    RegularUrl = "RegularUrl4",
                    SmallUrl = "SmallUrl4",
                    ThumbUrl = "ThumbUrl4",
                    UserName = "Jorge Britez 4",
                    UserHtmlLink = "UserHtmlLink4",
                    UserProfileImageSmall = "UserProfileImageSmall4"
                }
            }
        };

        public static List<Album> albums = 
            new List<Album>(new Album[] { album_1, album_2 });

    }
}
