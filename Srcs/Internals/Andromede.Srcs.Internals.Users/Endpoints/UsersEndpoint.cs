using Andromede.Srcs.Internals.Users.Interfaces;
using Grpc.Core;
using UsersService;
using UsersServiceBase = UsersService.UsersService.UsersServiceBase;

namespace Andromede.Srcs.Internals.Users.Endpoints;

internal sealed class UsersEndpoint(IUsersService usersService) : UsersServiceBase
{
    public override async Task<GetUserByIdResponse> GetUserById(GetUserByIdRequest request, ServerCallContext context)
    {
        var askedUser = request.UserId;

        var result = new GetUserByIdResponse
        {
            User = new User
            {
                Id = askedUser,
                Name = "John Doe",
                Email = "[email protected]"
            }
        };

        var res = await usersService.GetUsersByIdAsync(askedUser);

        var response = new GetUserByIdResponse
        {
            User = new User
            {
                Id = res.UsersId,
                Name = res.Username
            }
        };

        return await Task.FromResult(response);
    }

    public override Task<CreateUserResponse> CreateUser(CreateUserRequest request, ServerCallContext context)
    {
        return base.CreateUser(request, context);
    }

    public override Task<UpdateUserResponse> UpdateUser(UpdateUserRequest request, ServerCallContext context)
    {
        return base.UpdateUser(request, context);
    }

    public override Task<DeleteUserByIdResponse> DeleteUserById(DeleteUserByIdRequest request,
        ServerCallContext context)
    {
        return base.DeleteUserById(request, context);
    }
}