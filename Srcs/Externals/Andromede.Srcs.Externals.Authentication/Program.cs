using Andromede.Orchestrator.Services;
using Andromede.Srcs.Externals.Authentication.Endpoints;
using Andromede.Srcs.Externals.Authentication.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc(options => { options.EnableDetailedErrors = true; });
builder.AddServiceDefaults();
//builder.AddRedisOutputCache("cache");
builder.AddRedisDistributedCache("cache");

builder.Services.AddAuthenticationDependencies();

// add grpc client to port 6000
builder.Services.AddGrpcClient<UsersService.UsersService.UsersServiceClient>(options =>
{
    options.Address = new Uri("https://localhost:6000");
    //options.ChannelOptionsActions.Add(channelOptions => { channelOptions.Credentials = ChannelCredentials.Insecure; });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.MapGrpcService<AuthenticationEndpoint>();

app.Run();