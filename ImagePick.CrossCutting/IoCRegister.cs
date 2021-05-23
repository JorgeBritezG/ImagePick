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
            
            return services;

        }


        private static IServiceCollection AddRegisterRepositories( IServiceCollection services )
        {
            services.AddTransient<IAlbumRepository, AlbumRepository>();


            return services;

        }
    }
}
