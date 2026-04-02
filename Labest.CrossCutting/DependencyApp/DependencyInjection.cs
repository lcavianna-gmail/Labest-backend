using Labest.Application.Services;
using Labest.Domain.Entities;
using Labest.Domain.Interfaces;
using Labest.Infra.Context;
using Labest.Infra.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Labest.CrossCutting.DependencyApp
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("LabestDb"));

            services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey =
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes("12345678901234567890123456789012"))
        };
    });


            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<EstoqueService>();

            return services;
        }
    }
}
