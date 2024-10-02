using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using Andromede.Srcs.Externals.Authentication.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using UsersService;

namespace Andromede.Srcs.Externals.Authentication.Services;

internal sealed record AuthenticationService(IUsersRepository UsersRepository, IDistributedCache Cache)
    : IAuthenticationService
{
    [RequiresDynamicCode("Calls System.Text.Json.JsonSerializer.Deserialize<TValue>(String, JsonSerializerOptions)")]
    [UnconditionalSuppressMessage("Trimming",
        "IL2026:Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code",
        Justification = "<Pending>")]
    public async Task<GetUserByIdResponse> GetUserByIdAsync(int id)
    {
        var cacheKey = $"User_{id}";
        var cacheValue = await Cache.GetStringAsync(cacheKey);
        if (cacheValue != null) return JsonSerializer.Deserialize<GetUserByIdResponse>(cacheValue);

        var result = await UsersRepository.GetUserByIdAsync(id);

        await Cache.SetStringAsync(cacheKey, JsonSerializer.Serialize(result));

        return result;
    }
}