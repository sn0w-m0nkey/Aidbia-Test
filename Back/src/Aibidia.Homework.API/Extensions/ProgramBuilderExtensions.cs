using Aibidia.Homework.API.Services;

namespace Aibidia.Homework.API.Extensions;

public static class ProgramBuilderExtensions
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IResumeService, ResumeService>();
        
        return services;
    }
}
