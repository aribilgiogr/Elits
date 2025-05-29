using Business.Services;
using Core.Abstracts;
using Core.Abstracts.IServices;
using Core.Concretes.Entities;
using Data;
using Data.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Middlewares
{
    public static class CustomServiceExtensions
    {
        public static IServiceCollection AddDatabaseConnections(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(configuration.GetConnectionString("default")));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddDTOServices(this IServiceCollection services)
        {
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IPostLikeService, PostLikeService>();
            services.AddScoped<IFollowerService, FollowerService>();
            return services;
        }
    }
}
