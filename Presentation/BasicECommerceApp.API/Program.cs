using BasicECommerceApp.API.Filters;
using BasicECommerceApp.API.Middlewares;
using BasicECommerceApp.Application;
using BasicECommerceApp.Application.Configurations.Auth;
using BasicECommerceApp.Application.Features.Commands.Product.CreateProduct;
using BasicECommerceApp.Application.Services.Auth;
using BasicECommerceApp.Application.UnitOfWork;
using BasicECommerceApp.Domain.Entities.Auth;
using BasicECommerceApp.Persistance;
using BasicECommerceApp.Persistance.Contexts;
using BasicECommerceApp.Persistance.Services.Auth;
using BasicECommerceApp.Persistance.UnitOfWork;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute()))
    .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<CreateProductCommandValidator>());

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddDbContext<BasicECommerceAppDbContext>(x =>
{
    x.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(BasicECommerceAppDbContext)).GetName().Name);
    });
});

builder.Services.AddIdentity<AppUser, AppRole>(Opt =>
{
    Opt.User.RequireUniqueEmail = true; // Email adresi unique olmalý
    Opt.Password.RequireNonAlphanumeric = false; // *? gibi karakterlerin kullanýmýný zorunlu tutma... (Normalde default olarak zorunludur)
}).AddEntityFrameworkStores<BasicECommerceAppDbContext>().AddDefaultTokenProviders();

builder.Services.Configure<CustomTokenOption>(builder.Configuration.GetSection("TokenOption"));
builder.Services.Configure<Client>(builder.Configuration.GetSection("Clients"));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opts =>
{
    var tokenOptions = builder.Configuration.GetSection("TokenOption").Get<CustomTokenOption>();
    opts.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audience[0],
        IssuerSigningKey = SignService.GetSymmetricSecurityKey(tokenOptions.SecurityKey),
        ValidateIssuerSigningKey = true,
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddPersistanceServices();
builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCustomException();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
