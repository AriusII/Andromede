using UsersService;

namespace Andromede.Srcs.Externals.Authentication.Interfaces;

internal interface IUsersRepository
{
    Task<GetUserByIdResponse> GetUserByIdAsync(int id);
}