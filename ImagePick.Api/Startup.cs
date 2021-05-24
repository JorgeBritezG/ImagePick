using ImagePick.Api.Config;
using ImagePick.CrossCutting;
using ImagePick.DataAccess;
using ImagePick.DataAccess.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ImagePick.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices( IServiceCollection services )
        {
            services.AddControllers()
                    .AddNewtonsoftJson();

            services.AddTransient<IImagePickDbContext, ImagePickDbContext>();
            services.AddDbContext<ImagePickDbContext>(options =>
                options.UseSqlite("Data Source=ImagePickDb.db"));

            IoCRegister.AddRegistration(services);

            SwaggerConfig.AddRegistration(services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app, IWebHostEnvironment env )
        {
            if ( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(c => 
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ImagePick API V1"));

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
