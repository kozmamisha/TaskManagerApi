using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TaskManager.BusinessLogic.Extensions;
using TaskManager.DataAccess.Extensions;
using TaskManager.Infrastructure;
//using TaskManagerApi.Endpoints;
using TaskManagerApi.Mappers;
using AutoMapper;
using TaskManagerApi.Extensions;
using Microsoft.AspNetCore.CookiePolicy;
using TaskManager.DataAccess;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

//builder.Services.AddEndpointsApiExplorer();

builder.Services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
builder.Services.Configure<AuthorizationOptions>(configuration.GetSection(nameof(AuthorizationOptions)));

builder.Services.AddApiAuthentication(builder.Configuration);

builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddBusinessLogic();

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// additional protection for cookies
app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    Secure = CookieSecurePolicy.Always,
    HttpOnly = HttpOnlyPolicy.Always,
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
