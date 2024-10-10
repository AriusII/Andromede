using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var sqlServer = builder
    .AddSqlServer("sqlserver")
    .WithEnvironment("ACCEPT_EULA", "Y")
    .WithEnvironment("MSSQL_PID", "Developer")
    .WithDataVolume("sqlserver-data");

var redis = builder
    .AddRedis("cache")
    .WithImage("redis")
    .WithDataVolume("redis-data");

var internalUsers = builder
    .AddProject<Andromede_Srcs_Internals_Users>("Internal-Api-Users")
    .WithReference(redis)
    .WithReference(sqlServer)
    .WithReplicas(2);

var gatewayAuthentication = builder
    .AddProject<Andromede_Srcs_Gateway_Authentication>("Gateway-Authentication")
    .WithReference(redis)
    .WithReference(internalUsers);

builder.Build().Run();