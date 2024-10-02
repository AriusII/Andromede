using Andromede.Srcs.Internals.Users.Interfaces;

namespace Andromede.Srcs.Internals.Users.Services;

internal sealed record UsersService(IUsersRepository UsersRepository) : IUsersService
{
    public async Task<Repositories.Models.Users> GetUsersByIdAsync(int id)
    {
        //var newUser = new Repositories.Models.Users(1, Guid.NewGuid(), "John Doe");
        return await UsersRepository.GetUsersByIdAsync(id);
    }
}