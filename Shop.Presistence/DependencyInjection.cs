using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;

namespace Shop.Presistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<DataBaseContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IDataBaseContext>(provider =>
            provider.GetService<DataBaseContext>());
            return services;
        }
    }
}
