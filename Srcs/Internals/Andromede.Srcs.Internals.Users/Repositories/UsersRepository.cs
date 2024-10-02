using System.Data;
using Andromede.Srcs.Internals.Users.Interfaces;
using CaeriusNet.Builders;
using CaeriusNet.Commands.Reads;
using CaeriusNet.Factories;

namespace Andromede.Srcs.Internals.Users.Repositories;

internal sealed record UsersRepository(ICaeriusDbConnectionFactory Database)
    : IUsersRepository
{
    public async Task<Models.Users> GetUsersByIdAsync(int id)
    {
        var spParameters = new StoredProcedureParametersBuilder("Users.sp_Get_Users_By_Id")
            .AddParameter("UsersId", id, SqlDbType.Int);
        var result = await Database.FirstQueryAsync<Models.Users>(spParameters);
        return result;
    }
}