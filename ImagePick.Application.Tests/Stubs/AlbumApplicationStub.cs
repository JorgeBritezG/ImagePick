using ImagePick.Application.Contracts.Models;
using System;
using System.Collections.Generic;

namespace ImagePick.Application.Unit.Tests.Stubs
{
    public static class AlbumApplicationStub
    {
        
        public static AlbumApplication album_null = null;

        public static AlbumApplication album_AddOrUpdate = new AlbumApplication()
        {
            Id = 1,
            CreatedAt = DateTime.Now,
            Name = "Me Gusta",
            UserId = 1,
            
        };

        public static AlbumApplication album_1 = new AlbumApplication()
        {
            Id = 1,
            CreatedAt = DateTime.Now,
            Name = "Me Gusta",
            UserId = 1,
            Images = new List<ImageApplication>()
            {
                new ImageApplication() 
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
                new ImageApplication()
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

        public static AlbumApplication album_2 = new AlbumApplication()
        {
            Id = 1,
            CreatedAt = DateTime.Now,
            Name = "Favoritos",
            UserId = 1,
            Images = new List<ImageApplication>()
            {
                new ImageApplication()
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
                new ImageApplication()
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

        public static List<AlbumApplication> albums = 
            new List<AlbumApplication>(new AlbumApplication[] { album_1, album_2 });

    }
}
