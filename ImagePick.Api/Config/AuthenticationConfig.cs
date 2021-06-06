using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ImagePick.Api.Config
{
    public static class AuthenticationConfig
    {
        public static IServiceCollection ConfigureAuthenticationSettings( IServiceCollection services, IConfiguration configuration )
        {
            services.AddAuthentication(x => {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration[ "Authentication:Jwt:Secret" ])),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            })
              .AddGoogle(options => {
                  options.ClientId = configuration[ "Authentication:Google:ClientId" ];
                  options.ClientSecret = configuration[ "Authentication:Google:ClientSecret" ];
              });

            return services;
        }
    }
}
