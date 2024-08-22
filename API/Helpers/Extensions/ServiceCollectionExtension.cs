
using Businnes.Repositories.Interfaces;
using Bussines.Repositories.Interfaces;
using Bussines.Services;
using Bussines.Services.Interfaces;
using Data.Context;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Helpers.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddScopeds(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUnitOfWorkService, UnitOfWorkService>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();

            return services;
        }
        public static IServiceCollection AddDbContext(this IServiceCollection services, string defaultConnection)
        {
            return services.AddDbContext<DataContext>(options => options.UseSqlServer(defaultConnection));
        }
    }
}
