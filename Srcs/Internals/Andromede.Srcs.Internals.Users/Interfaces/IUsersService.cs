namespace Andromede.Srcs.Internals.Users.Interfaces;

internal interface IUsersService
{
    Task<Repositories.Models.Users> GetUsersByIdAsync(int id);
}