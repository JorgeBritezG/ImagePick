using ImagePick.Application.Contracts.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImagePick.Application.Unit.Tests.MockService
{
    public class AlbumServiceMock
    {
        public Mock<IAlbumService> _albumService { get; set; }

        public AlbumServiceMock()
        {
            _albumService = new Mock<IAlbumService>();
            Setup();
        }

        private void Setup()
        {

        }
    }
}
