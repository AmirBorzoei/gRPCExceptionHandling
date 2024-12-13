using System.Collections.ObjectModel;
using gRPCExceptionHandling.Domain.Users;

namespace gRPCExceptionHandling.ApplicationService;

public class UserApplicationService
{
    private readonly IUserRepository _userRepository;

    public UserApplicationService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetAsync(Guid id, CancellationToken cancellation)
    {
        return await _userRepository.GetAsync(id, cancellation);
    }

    public async Task<ReadOnlyCollection<User>> GetAllAsync(CancellationToken cancellation)
    {
        return await _userRepository.GetAllAsync(cancellation);
    }

    public async Task SaveAsync(User user, CancellationToken cancellation)
    {
        await _userRepository.SaveAsync(user, cancellation);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellation)
    {
        await _userRepository.DeleteAsync(id, cancellation);
    }
}