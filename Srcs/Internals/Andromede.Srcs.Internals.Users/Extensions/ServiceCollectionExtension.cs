using Andromede.Srcs.Internals.Users.Interfaces;
using Andromede.Srcs.Internals.Users.Repositories;

namespace Andromede.Srcs.Internals.Users.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddUsersDependencies(this IServiceCollection services)
    {
        return services
            .AddScoped<IUsersRepository, UsersRepository>()
            .AddScoped<IUsersService, Services.UsersService>();
    }
}