using DemoCRUD.Application.MappingImplementation;
using DemoCRUD.Application.MappingInterface;
using DemoCRUD.Application.UseCaseImplementation;
using DemoCRUD.Application.UseCaseInterface;
using Microsoft.Extensions.DependencyInjection;

namespace DemoCRUD.Application.DependencyInjection;

public static class ServiceContainer
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductMapper, ProductMapper>();
        return services;
    }
}