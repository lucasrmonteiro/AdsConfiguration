using AdsConfiguration.Application.Interfaces;
using AdsConfiguration.Application.Services;
using AdsConfiguration.Data.Context;
using AdsConfiguration.Data.Interfaces;
using AdsConfiguration.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AdsConfiguration.Application.DI;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IAdsService, AdsService>();
        return services;
    }
    
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
        services.AddScoped<IAdsRepository, AdsRepository>();
        return services;
    }
    
    public static IServiceCollection AddDbContext(this IServiceCollection services)
    {
        services.AddDbContext<ApiContext>(options =>
        {
            options.UseInMemoryDatabase(databaseName: "AdsDB");
        });
        return services;
    }
}
