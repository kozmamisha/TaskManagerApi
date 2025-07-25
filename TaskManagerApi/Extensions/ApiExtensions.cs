﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TaskManager.BusinessLogic.Interfaces;
using TaskManager.BusinessLogic.Services;
using TaskManager.DataAccess.Enums;
using TaskManagerApi.Authorization;

namespace TaskManagerApi.Extensions
{
    public static class ApiExtensions
    {
        public static void AddApiAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtOptions = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();

            services
                .AddAuthorization(x =>
                {
                    x.AddPolicy(nameof(PermissionEnum.Create),
                    builder => builder
                        .Requirements.Add(new PermissionRequirements([PermissionEnum.Create])));
                    x.AddPolicy(nameof(PermissionEnum.Read),
                    builder => builder
                        .Requirements.Add(new PermissionRequirements([PermissionEnum.Read])));
                    x.AddPolicy(nameof(PermissionEnum.Update),
                    builder => builder
                        .Requirements.Add(new PermissionRequirements([PermissionEnum.Update])));
                    x.AddPolicy(nameof(PermissionEnum.Delete),
                    builder => builder
                        .Requirements.Add(new PermissionRequirements([PermissionEnum.Delete])));
                })
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    // it will take and try to validate token from Authorization header
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions!.SecretKey))
                    };

                    // for validating token from cookies
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            context.Token = context.Request.Cookies["tasty-cookie"];

                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();

            services.AddAuthorization();
        }
    }
}
