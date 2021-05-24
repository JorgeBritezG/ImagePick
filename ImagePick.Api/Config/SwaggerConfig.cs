using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace ImagePick.Api.Config
{
    public static class SwaggerConfig
    {

        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {


            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Version = "v1",
                    Title = "ImagePick API", 
                    Description = "Edge Work Test in ASP.NET Core web API.",
                    Contact = new OpenApiContact
                    {
                        Name = "Jorge Britez",
                        Email = "jorgedanielbritezg@gmail.com",
                        Url = new Uri("https://github.com/JorgeBritezG/ImagePick"),
                    }
                });
            
            });

            return services;
        }
    }
}
