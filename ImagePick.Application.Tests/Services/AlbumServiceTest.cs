using FluentAssertions;
using ImagePick.Application.Contracts.Models;
using ImagePick.Application.Contracts.Services;
using ImagePick.Application.Services;
using ImagePick.Application.Unit.Tests.MockRespository;
using ImagePick.Application.Unit.Tests.Stubs;
using ImagePick.DataAccess.Contracts.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace ImagePick.Application.Unit.Tests.Services
{
    [TestClass]
    public class AlbumServiceTest
    {
        private static IAlbumService _albumService;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            Mock<IAlbumRepository> _albumRepository = new AlbumRepositoryMock()._albumRepository;

            _albumService = new AlbumService(_albumRepository.Object);
        }

        [TestMethod]
        public async Task AddAsync_CreateNewAlbum_Ok()
        {
            //Arrange 
            var expected = AlbumApplicationStub.album_AddOrUpdate;

            //Act
            var actual = await _albumService.AddAsync(expected);

            //Assert
            actual.Should().BeOfType(typeof(AlbumApplication));
            actual.Should().NotBeNull();
            actual.Should().Equals(expected);
            actual.Id.Should().NotBe(0);
        }

        [TestMethod]
        public async Task UpdateAsync_UpdateAlbum_Ok()
        {
            //Arrange 
            var expected = AlbumApplicationStub.album_AddOrUpdate;

            //Act
            var actual = await _albumService.UpdateAsync(expected);

            //Assert
            actual.Should().BeOfType(typeof(AlbumApplication));
            actual.Should().NotBeNull();
            actual.Should().Equals(expected);
            actual.Id.Should().NotBe(0);
        }

        [TestMethod]
        public async Task DeleteAsync_ById_Ok()
        {
            //Arrange 
            int id = 3;

            //Act
            var actual = await _albumService.DeleteAsync(id);

            //Assert
            actual.Should().BeTrue();
        }

        [TestMethod]
        public async Task DeleteAsync_ById_InvalidId()
        {
            //Arrange 
            int id = 1;

            //Act
            var actual = await _albumService.DeleteAsync(id);

            //Assert
            actual.Should().BeFalse();
        }

        [TestMethod]
        public async Task GetAllAsync_ok()
        {
            //Arrange 
            var expected = AlbumApplicationStub.albums;

            //Act
            var actual = await _albumService.GetAllAsync();

            //Assert
            actual.Should().AllBeOfType(typeof(AlbumApplication));
            actual.Should().NotBeNull();
            actual.Should().Equals(expected);
            actual.Should().HaveCountGreaterThan(0);
        }

        [TestMethod]
        public async Task GetAsync_ById_ok()
        {
            //Arrange 
            int id = 1;
            var expected = AlbumApplicationStub.album_1;

            //Act
            var actual = await _albumService.GetAsync(id);

            //Assert
            actual.Should().BeOfType(typeof(AlbumApplication));
            actual.Should().NotBeNull();
            actual.Should().Equals(expected);
            actual.Images.Should().AllBeOfType(typeof(ImageApplication));
        }

        [TestMethod]
        public async Task GetAsync_ById_InvalidId_ExpectedNulL()
        {
            //Arrange 
            int id = 3;

            //Act
            var actual = await _albumService.GetAsync(id);

            //Assert
            actual.Should().BeNull();
        }


    }
}
