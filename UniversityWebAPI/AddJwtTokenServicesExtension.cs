using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using UniversityWebAPI.Models.DataModel;

namespace UniversityWebAPI
{
    public static class AddJwtTokenServicesExtension
    {
        public static void AddJwtTokenServices(this IServiceCollection services, IConfiguration configuration)
        {
            //add JWT Setting
            var bindJwtSetting = new JwtSetting();
            configuration.Bind("JsonWebTokenKeys", bindJwtSetting);

            //add singleton of JWT Setting
            services.AddSingleton(bindJwtSetting);

            services
                .AddAuthentication(option =>
                {
                    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

                })
                .AddJwtBearer(option =>
                {
                    option.RequireHttpsMetadata = false;
                    option.SaveToken = true;
                    option.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = bindJwtSetting.ValidateIssuerSigningKey,
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(bindJwtSetting.IssuerSigningKey)),
                        ValidateIssuer = bindJwtSetting.ValidateIssuer,
                        ValidIssuer = bindJwtSetting.ValidIssuer,
                        ValidateAudience = bindJwtSetting.ValidateAudience,
                        ValidAudience = bindJwtSetting.ValidAudience,
                        RequireExpirationTime = bindJwtSetting.RequireExpirationTime,
                        ValidateLifetime = bindJwtSetting.ValidateLifeTime,
                        ClockSkew = TimeSpan.FromDays(1)
                    };
                });
        }

    }
}

