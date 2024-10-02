using CaeriusNet.Mappers;
using Microsoft.Data.SqlClient;

namespace Andromede.Srcs.Internals.Users.Repositories.Models;

internal sealed record Users(int UsersId, Guid UsersGuid, string Username) : ISpMapper<Users>
{
    public static Users MapFromReader(SqlDataReader reader)
    {
        return new Users(
            reader.GetInt32(0),
            reader.GetGuid(1),
            reader.GetString(3)
        );
    }
}