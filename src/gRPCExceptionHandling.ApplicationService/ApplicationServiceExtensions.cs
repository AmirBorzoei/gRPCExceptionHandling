using gRPCExceptionHandling.ApplicationService;
using Microsoft.Extensions.DependencyInjection;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<UserApplicationService>();

        return services;
    }
}