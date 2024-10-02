using Andromede.Srcs.Externals.Authentication.Interfaces;
using AuthenticationService;
using Grpc.Core;
using AuthenticationServiceBase = AuthenticationService.AuthenticationService.AuthenticationServiceBase;

namespace Andromede.Srcs.Externals.Authentication.Endpoints;

internal sealed class AuthenticationEndpoint(IAuthenticationService authenticationService) : AuthenticationServiceBase
{
    public override async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request,
        ServerCallContext context)
    {
        var requestValues = new AuthenticateRequest
        {
            Email = request.Email,
            Password = request.Password
        };

        const int test = 45;
        var value = await authenticationService.GetUserByIdAsync(test);

        var response = new AuthenticateResponse
        {
            Token = value.User.Name
        };


        return response;
    }

    public override Task<RegisterResponse> Register(RegisterRequest request, ServerCallContext context)
    {
        return base.Register(request, context);
    }
}