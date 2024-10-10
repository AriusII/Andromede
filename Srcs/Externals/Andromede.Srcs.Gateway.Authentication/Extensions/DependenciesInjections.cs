using Andromede.Srcs.Externals.Authentication.Interfaces;
using Andromede.Srcs.Externals.Authentication.Repositories;

namespace Andromede.Srcs.Externals.Authentication.Extensions;

internal static class DependenciesInjections
{
    internal static IServiceCollection AddAuthenticationDependencies(this IServiceCollection services)
    {
        return services
            .AddScoped<IUsersRepository, UsersRepository>()
            .AddScoped<IAuthenticationService, Services.AuthenticationService>();
    }
}