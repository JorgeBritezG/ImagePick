using ImagePick.Api.Config;
using ImagePick.CrossCutting;
using ImagePick.DataAccess;
using ImagePick.DataAccess.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ImagePick.Api
{
    public class Startup
    {
        public Startup( IConfiguration configuration )
        {
            Configuration = configuration;
            StaticConfig = configuration;
        }
        public IConfiguration Configuration { get; }
        public static IConfiguration StaticConfig { get; private set; }

        public void ConfigureServices( IServiceCollection services )
        {
            

            services.AddCors();

            services.AddTransient<IImagePickDbContext, ImagePickDbContext>();
            services.AddDbContext<ImagePickDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            IdentityConfig.CreateIdentityIfNotCreated(services);

            AuthenticationConfig.ConfigureAuthenticationSettings(services, Configuration);

            IoCRegister.AddRegistration(services);

            SwaggerConfig.AddRegistration(services);

            services.AddControllers(options => options.RespectBrowserAcceptHeader = true)
                    .AddNewtonsoftJson();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app, IWebHostEnvironment env )
        {
            if ( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseCors(it => it.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseSwagger();

            app.UseSwaggerUI(c => 
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ImagePick API V1"));

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
