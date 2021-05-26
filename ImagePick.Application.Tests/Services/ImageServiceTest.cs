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
    public class ImageServiceTest
    {
        private static IImageService _imageService;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            Mock<IImageRepository> _imageRepository = new ImageRepositoryMock()._imageRepository;

            _imageService = new ImageService(_imageRepository.Object);
        }

        [TestMethod]
        public async Task AddAsync_CreateNewImage_Ok()
        {
            //Arrange 
            var expected = ImageApplicationStub.image_1;

            //Act
            var actual = await _imageService.AddAsync(expected);

            //Assert
            actual.Should().BeOfType(typeof(ImageApplication));
            actual.Should().NotBeNull();
            actual.Should().Equals(expected);
            actual.Id.Should().NotBe(0);
            actual.UserName.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public async Task UpdateAsync_UpdateImage_Ok()
        {
            //Arrange 
            var expected = ImageApplicationStub.image_1;

            //Act
            var actual = await _imageService.UpdateAsync(expected);

            //Assert
            actual.Should().BeOfType(typeof(ImageApplication));
            actual.Should().NotBeNull();
            actual.Should().Equals(expected);
            actual.Id.Should().NotBe(0);
            actual.UserName.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public async Task DeleteAsync_ById_Ok()
        {
            //Arrange 
            int id = 3;

            //Act
            var actual = await _imageService.DeleteAsync(id);

            //Assert
            actual.Should().BeTrue();
        }

        [TestMethod]
        public async Task DeleteAsync_ById_InvalidId()
        {
            //Arrange 
            int id = 1;

            //Act
            var actual = await _imageService.DeleteAsync(id);

            //Assert
            actual.Should().BeFalse();
        }

        [TestMethod]
        public async Task GetAllAsync_ok()
        {
            //Arrange 
            var expected = ImageApplicationStub.images;

            //Act
            var actual = await _imageService.GetAllAsync();

            //Assert
            actual.Should().AllBeOfType(typeof(ImageApplication));
            actual.Should().NotBeNull();
            actual.Should().Equals(expected);
            actual.Should().HaveCountGreaterThan(0);
        }

        [TestMethod]
        public async Task GetAsync_ById_ok()
        {
            //Arrange 
            int id = 1;
            var expected = ImageApplicationStub.image_1;

            //Act
            var actual = await _imageService.GetAsync(id);

            //Assert
            actual.Should().BeOfType(typeof(ImageApplication));
            actual.Should().NotBeNull();
            actual.Should().Equals(expected);
        }

        [TestMethod]
        public async Task GetAsync_ById_InvalidId_ExpectedNulL()
        {
            //Arrange 
            int id = 3;

            //Act
            var actual = await _imageService.GetAsync(id);

            //Assert
            actual.Should().BeNull();
        }


    }
}
