using Microsoft.Extensions.DependencyInjection;

namespace Aibidia.Homework.DataAccess.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddMultiTenantDataAccess(this IServiceCollection services)
    {
        services.AddScoped<ITenantService, TenantService>();

        services.AddDbContext<ApplicationDbMultiTenantContext>();
        services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbMultiTenantContext>()!);

        return services;
    }
}
