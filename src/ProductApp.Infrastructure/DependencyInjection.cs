using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductApp.Application.Common.Interfaces;
using ProductApp.Infrastructure.Data;
using ProductApp.Infrastructure.Data.Repositories;

namespace ProductApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<SqlConnectionFactory>();
            services.AddScoped<ITestModelRepository, TestModelRepository>();

            return services;
        }
    }
}
