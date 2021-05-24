using ImagePick.Application.Contracts.Services;
using ImagePick.Application.Services;
using ImagePick.DataAccess.Contracts.Repositories;
using ImagePick.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ImagePick.CrossCutting
{
    public static class IoCRegister
    {
        public static IServiceCollection AddRegistration( this IServiceCollection services )
        {
            AddRegisterServices(services);
            AddRegisterRepositories(services);

            return services;
            
        }

        private static IServiceCollection AddRegisterServices(IServiceCollection services)
        {
            services.AddTransient<IAlbumService, AlbumService>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<IUserService, UserService>();

            return services;

        }


        private static IServiceCollection AddRegisterRepositories( IServiceCollection services )
        {
            services.AddTransient<IAlbumRepository, AlbumRepository>();
            services.AddTransient<IImageRepository, ImageRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            return services;

        }
    }
}
