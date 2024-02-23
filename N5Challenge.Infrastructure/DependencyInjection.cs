using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using N5Challenge.Application.Common.DTO;
using N5Challenge.Application.Common.Interfaces;
using N5Challenge.Infrastructure.Common;
using N5Challenge.Infrastructure.Common.Persistence;
using N5Challenge.Infrastructure.Permissions;
using N5Challenge.Infrastructure.Services;
using Nest;

namespace N5Challenge.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddElasticsearch(configuration);

            return services;
        }

        private static IServiceCollection AddElasticsearch(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionSettings = new ConnectionSettings(new Uri(configuration["ElasticSearch:Uri"]!)).DefaultIndex(configuration["ElasticSearch:Index"]);
            var client = new ElasticClient(connectionSettings);

            services.AddSingleton(client);
            services.AddScoped<IElasticsearchService<ElasticRegistryDTO>, ElasticsearchService<ElasticRegistryDTO>>();

            return services;
        }
    }
}
