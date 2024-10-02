namespace Andromede.Srcs.Internals.Users.Interfaces;

internal interface IUsersRepository
{
    Task<Repositories.Models.Users> GetUsersByIdAsync(int id);
}