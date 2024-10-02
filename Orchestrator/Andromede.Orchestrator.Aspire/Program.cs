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

var serviceLogging = builder
    .AddProject<Andromede_Srcs_Services_Logging>("Internal-Service-Logging")
    .WithReference(sqlServer);

var serviceMailling = builder
    .AddProject<Andromede_Srcs_Services_Mailling>("Internal-Service-Mailling");

var internalUsers = builder
    .AddProject<Andromede_Srcs_Internals_Users>("Internal-Api-Users")
    .WithReference(redis)
    .WithReference(sqlServer)
    .WithReplicas(2);

var externalAuthentication = builder
    .AddProject<Andromede_Srcs_Externals_Authentication>("External-Bff-Authentication")
    .WithReference(redis)
    .WithReference(internalUsers);

builder.Build().Run();