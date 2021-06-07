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
                x.DeleteAsync(It.Is<string>(p => p.Equals("x"))))
                .ReturnsAsync(true);

            //DeleteAsync false
            _imageRepository.Setup(x =>
                x.DeleteAsync(It.Is<string>(p => !p.Equals("x"))))
                .ReturnsAsync(false);

            //GetAllAsync
            _imageRepository.Setup(x =>
                x.GetAllAsync()).ReturnsAsync(ImageStub.images);

            //GetAsync by id xxx
            _imageRepository.Setup(x =>
                x.GetAsync(It.Is<string>(p => p.Equals("xxx"))))
                .ReturnsAsync(ImageStub.image_1);

            //GetAsync by not id 1
            _imageRepository.Setup(x =>
                x.GetAsync(It.Is<string>(p => !p.Equals("xxx"))))
                .ReturnsAsync(ImageStub.image_null);

            //UpdateAsync
            _imageRepository.Setup(x =>
                x.UpdateAsync(It.IsAny<Image>()))
                .ReturnsAsync(ImageStub.image_1);
        }
    }
}
