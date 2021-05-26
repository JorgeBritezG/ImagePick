using ImagePick.Application.Unit.Tests.Stubs;
using ImagePick.DataAccess.Contracts.Entities;
using ImagePick.DataAccess.Contracts.Repositories;
using Moq;

namespace ImagePick.Application.Unit.Tests.MockRespository
{
    public class ImageRepositoryMock
    {
       public Mock<IImageRepository> _imageRepository { get; set; }

        public ImageRepositoryMock()
        {
            _imageRepository = new Mock<IImageRepository>();
            Setup();
        }

        private void Setup()
        {
            //AddAsync
            _imageRepository.Setup(x => 
                x.AddAsync(It.IsAny<Image>()))
                .ReturnsAsync(ImageStub.image_1);

            //DeleteAsync true
            _imageRepository.Setup(x =>
                x.DeleteAsync(It.Is<int>(p => p.Equals(3))))
                .ReturnsAsync(true);

            //DeleteAsync false
            _imageRepository.Setup(x =>
                x.DeleteAsync(It.Is<int>(p => !p.Equals(3))))
                .ReturnsAsync(false);

            //GetAllAsync
            _imageRepository.Setup(x =>
                x.GetAllAsync()).ReturnsAsync(ImageStub.images);

            //GetAsync by id 1
            _imageRepository.Setup(x =>
                x.GetAsync(It.Is<int>(p => p.Equals(1))))
                .ReturnsAsync(ImageStub.image_1);

            //GetAsync by not id 1
            _imageRepository.Setup(x =>
                x.GetAsync(It.Is<int>(p => !p.Equals(1))))
                .ReturnsAsync(ImageStub.image_null);

            //UpdateAsync
            _imageRepository.Setup(x =>
                x.UpdateAsync(It.IsAny<Image>()))
                .ReturnsAsync(ImageStub.image_1);
        }
    }
}
