﻿using Dail.Application.Common.Interfaces;
using Dail.Application.Common.Models;
using Dail.Domain.Entities;
using Dail.Infrastructure.Jwt;
using Dail.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Dail.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;

namespace Dail.Infrastructure;
public static class DependencyContainer
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var appSettingsSection = configuration.GetSection("AppSettings");
        services.Configure<AppSettings>(appSettingsSection);
        var appSettings = appSettingsSection.Get<AppSettings>();


        services.AddEntityFrameworkSqlServer();
        if (appSettings.UseInMemoryDatabase)
        {
            services.AddDbContext<DailContext>(options =>
                options.UseInMemoryDatabase("DailDb"));
        }
        else
        {
            services.AddDbContext<DailContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                          b =>
                          {
                              b.MigrationsAssembly(typeof(DailContext).Assembly.FullName);
                          });

                options.UseInternalServiceProvider(serviceProvider);
            });
        }


        services.AddIdentityCore<ApplicationUser>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.Password.RequireDigit = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;
        }).AddRoles<IdentityRole>()
          .AddEntityFrameworkStores<DailContext>();
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(appSettings.Jwt.Key)),
                ValidateIssuer = false,
                ValidateAudience = false,
            };
        });

        services.AddScoped<IDailContext>(provider => provider.GetService<DailContext>()!);

        services.AddScoped<IJwtHandler, JwtHandler>();
        services.AddScoped<IDateTime, DateTimeService>();
    }

    public static async Task SeedDatabase(this IServiceProvider service)
    {
        using (var scope = service.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<DailContext>();
            if (context.Database.IsSqlServer())
            {
                context.Database.Migrate();
            }
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            await DailContextSeed.SeedRolesAsync(roleManager);
            await DailContextSeed.SeedDefaultUserAsync(userManager);
        }
    }
}