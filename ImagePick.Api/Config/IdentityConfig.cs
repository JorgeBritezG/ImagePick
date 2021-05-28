using ImagePick.DataAccess;
using ImagePick.DataAccess.Contracts.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ImagePick.Api.Config
{
    public static class IdentityConfig
    {
        public static IServiceCollection CreateIdentityIfNotCreated(IServiceCollection services)
        {
            var sp = services.BuildServiceProvider();
            using var scope = sp.CreateScope();
            var existingUserManager = scope.ServiceProvider.GetService<UserManager<User>>();
            if (existingUserManager == null)
            {
                services.AddIdentity<User, IdentityRole>()
                        .AddEntityFrameworkStores<ImagePickDbContext>()
                        .AddDefaultTokenProviders();

            }

            return services;
        }
    }
}
