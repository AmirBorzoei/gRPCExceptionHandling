using System.Collections.ObjectModel;
using Framework.Core.ExceptionHandling;
using gRPCExceptionHandling.Domain.Users;

namespace gRPCExceptionHandling.Repository.InMemory.Users;

public class UserRepository : IUserRepository
{
    private readonly List<User> _users;

    public UserRepository()
    {
        _users = [];
    }

    public Task<User> GetAsync(Guid id, CancellationToken cancellation)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user is null)
        {
            throw new NotFoundException();
        }
        return Task.FromResult(user);
    }

    public Task<ReadOnlyCollection<User>> GetAllAsync(CancellationToken cancellation)
    {
        return Task.FromResult(_users.AsReadOnly());
    }

    public async Task SaveAsync(User user, CancellationToken cancellation)
    {
        var oldUser = _users.FirstOrDefault(u => u.Id == user.Id);
        if (oldUser is null)
        {
            _users.Add(user);
        }
        else
        {
            await DeleteAsync(user.Id, cancellation);
            _users.Add(user);
        }
    }

    public Task DeleteAsync(Guid id, CancellationToken cancellation)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user is not null)
        {
            _users.Remove(user);
        }
        return Task.CompletedTask;
    }
}