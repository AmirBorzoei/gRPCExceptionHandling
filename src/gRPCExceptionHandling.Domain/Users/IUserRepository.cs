using System.Collections.ObjectModel;

namespace gRPCExceptionHandling.Domain.Users;

public interface IUserRepository
{
    Task<User> GetAsync(Guid id, CancellationToken cancellation);
    Task<ReadOnlyCollection<User>> GetAllAsync(CancellationToken cancellation);
    Task SaveAsync(User user, CancellationToken cancellation);
    Task DeleteAsync(Guid id, CancellationToken cancellation);
}