using Andromede.Srcs.Externals.Authentication.Interfaces;
using UsersService;
using UsersServiceClient = UsersService.UsersService.UsersServiceClient;

namespace Andromede.Srcs.Externals.Authentication.Repositories;

internal sealed record UsersRepository(UsersServiceClient UsersServiceClient)
    : IUsersRepository
{
    public async Task<GetUserByIdResponse> GetUserByIdAsync(int id)
    {
        var value = new GetUserByIdRequest { UserId = id };
        var result = await UsersServiceClient.GetUserByIdAsync(value);
        return result;
    }
}