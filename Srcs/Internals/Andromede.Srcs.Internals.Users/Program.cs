using Andromede.Libs.Framework.Scripts;
using Andromede.Orchestrator.Services;
using Andromede.Srcs.Internals.Users.Endpoints;
using Andromede.Srcs.Internals.Users.Extensions;
using CaeriusNet.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddRedisOutputCache("cache");
builder.AddSqlServerClient("sqlserver");

string? andromedeCnxString = null;
if (builder.Configuration.GetConnectionString("sqlserver") is string connectionString)
    andromedeCnxString = connectionString;

DatabaseMigrator.Migrate(andromedeCnxString!);

builder.Services
    .RegisterCaeriusOrm(andromedeCnxString!)
    .AddUsersDependencies();

// Add services to the container.
builder.Services.AddGrpc(options => { options.EnableDetailedErrors = true; });

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.MapGrpcService<UsersEndpoint>();
app.Run();