using UsersService;

namespace Andromede.Srcs.Externals.Authentication.Interfaces;

internal interface IAuthenticationService
{
    Task<GetUserByIdResponse> GetUserByIdAsync(int id);
}