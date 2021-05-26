using ImagePick.Application.Unit.Tests.Stubs;
using ImagePick.DataAccess.Contracts.Entities;
using ImagePick.DataAccess.Contracts.Repositories;
using Moq;

namespace ImagePick.Application.Unit.Tests.MockRespository
{
    public class AlbumRepositoryMock
    {
       public Mock<IAlbumRepository> _albumRepository { get; set; }

        public AlbumRepositoryMock()
        {
            _albumRepository = new Mock<IAlbumRepository>();
            Setup();
        }

        private void Setup()
        {
            //AddAsync
            _albumRepository.Setup(x => 
                x.AddAsync(It.IsAny<Album>()))
                .ReturnsAsync(AlbumStub.album_1);

            //DeleteAsync true
            _albumRepository.Setup(x =>
                x.DeleteAsync(It.Is<int>(p => p.Equals(3))))
                .ReturnsAsync(true);

            //DeleteAsync false
            _albumRepository.Setup(x =>
                x.DeleteAsync(It.Is<int>(p => !p.Equals(3))))
                .ReturnsAsync(false);

            //GetAllAsync
            _albumRepository.Setup(x =>
                x.GetAllAsync()).ReturnsAsync(AlbumStub.albums);

            //GetAsync by id 1
            _albumRepository.Setup(x =>
                x.GetAsync(It.Is<int>(p => p.Equals(1))))
                .ReturnsAsync(AlbumStub.album_1);

            //GetAsync by not id 1
            _albumRepository.Setup(x =>
                x.GetAsync(It.Is<int>(p => !p.Equals(1))))
                .ReturnsAsync(AlbumStub.album_null);

            //UpdateAsync
            _albumRepository.Setup(x =>
                x.UpdateAsync(It.IsAny<Album>()))
                .ReturnsAsync(AlbumStub.album_1);
        }
    }
}
