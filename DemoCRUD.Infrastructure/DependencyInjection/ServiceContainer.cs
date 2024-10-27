using DemoCRUD.Domain.RepositoryInterface;
using DemoCRUD.Infrastructure.DataBaseContext;
using DemoCRUD.Infrastructure.RepositoryImplementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DemoCRUD.Infrastructure.DependencyInjection;

public static class ServiceContainer
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection services,
        IConfiguration config )
    {
        
        services.AddDbContext<AppDbContext>(
            o => o.UseSqlServer(config.GetConnectionString("DefaultConnection")));
        services.AddScoped<IProductRepository, ProductRepository>();
        
        return services;
    }
}