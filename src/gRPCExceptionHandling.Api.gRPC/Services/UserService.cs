using Grpc.Core;
using gRPCExceptionHandling.ApplicationService;
using gRPCExceptionHandling.Domain.Users;
using static gRPCExceptionHandling.Api.gRPC.UserServiceGrpc;

namespace gRPCExceptionHandling.Api.gRPC.Services;

public class UserService : UserServiceGrpcBase
{
    private readonly UserApplicationService _userApplicationService;

    public UserService(UserApplicationService userApplicationService)
    {
        _userApplicationService = userApplicationService;
    }

    public override async Task<UserGrpc> GetUser(UserIdGrpc request, ServerCallContext context)
    {
        var userId = Guid.Parse(request.Id);

        var user = await _userApplicationService.GetAsync(userId, context.CancellationToken);

        var response = new UserGrpc
        {
            Id = user.Id.ToString(),
            FirstName = user.FirstName,
            LastName = user.LastName,
            NationalCode = user.NationalCode,
            Birthdate = user.Birthdate.ToString("yyyy-MM-dd")
        };
        return response;
    }

    public override async Task<UserListGrpc> GetAllUsers(EmptyGrpc request, ServerCallContext context)
    {
        var users = await _userApplicationService.GetAllAsync(context.CancellationToken);

        var response = new UserListGrpc();
        var allUserGrpc = users.Select(u => new UserGrpc
        {
            Id = u.Id.ToString(),
            FirstName = u.FirstName,
            LastName = u.LastName,
            NationalCode = u.NationalCode,
            Birthdate = u.Birthdate.ToString("yyyy-MM-dd")
        });
        response.Users.AddRange(allUserGrpc);
        return response;
    }

    public override async Task<EmptyGrpc> CreateUser(UserGrpc request, ServerCallContext context)
    {
        var newUser = new User(Guid.Parse(request.Id),
                            request.NationalCode,
                            request.FirstName,
                            request.LastName,
                            DateOnly.Parse(request.Birthdate));

        await _userApplicationService.SaveAsync(newUser, context.CancellationToken);

        return new EmptyGrpc();
    }

    public override async Task<EmptyGrpc> UpdateUser(UserGrpc request, ServerCallContext context)
    {
        var newUser = new User(Guid.Parse(request.Id),
                            request.NationalCode,
                            request.FirstName,
                            request.LastName,
                            DateOnly.Parse(request.Birthdate));

        await _userApplicationService.SaveAsync(newUser, context.CancellationToken);

        return new EmptyGrpc();
    }

    public override async Task<EmptyGrpc> DeleteUser(UserIdGrpc request, ServerCallContext context)
    {
        var userId = Guid.Parse(request.Id);

        await _userApplicationService.DeleteAsync(userId, context.CancellationToken);

        return new EmptyGrpc();
    }
}