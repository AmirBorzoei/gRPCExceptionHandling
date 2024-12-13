using Microsoft.Extensions.DependencyInjection;
using gRPCExceptionHandling.Domain.Users;
using gRPCExceptionHandling.Repository.InMemory.Users;

namespace gRPCExceptionHandling.Repository.InMemory;

public static class RepositoryInMemoryExtensions
{
    public static IServiceCollection AddInMemoryRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IUserRepository, UserRepository>();

        return services;
    }
}