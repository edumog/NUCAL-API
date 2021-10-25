using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUCAL.Application.Core.Interfaces;
using NUCAL.Security.Models;
using NUCAL.Security.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using NUCAL.Security.Utilities;

namespace NUCAL.Security.Extensions
{
    public static class SecurityExtensions
    {
        public static string[] allowedOrigins = new string[] { "http://localhost:4200" };

        public static IServiceCollection AddSecurityDependencies(this IServiceCollection services)
        {
            services.AddTransient<IAccount, Account>();
            services.AddTransient<IUsersManager, UsersManager>();
            services.AddTransient<ITokenFactory, TokenFactory>();
            return services;
        }
        public static IServiceCollection AddSecurityDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SecurityDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("SecurityConnection")));

            return services;
        }

        public static IServiceCollection AddSecurityConfiguration(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<SecurityDbContext>()
                    .AddDefaultTokenProviders();
            return services;
        }

        public static IServiceCollection AddAuthenticationConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters { 
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT_KEY"])),
                        ClockSkew = TimeSpan.Zero
                    } );
            return services;
        }
    }
}
