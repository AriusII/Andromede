using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var sqlServer = builder
    .AddSqlServer("sqlserver")
    .WithEnvironment("ACCEPT_EULA", "Y")
    .WithEnvironment("MSSQL_PID", "Developer")
    .WithDataVolume("sqlserver-data");

var sqlServerDatabase = sqlServer
    .AddDatabase("Andromede-Database", "andromede");


var redis = builder
    .AddRedis("redis")
    .WithImage("redis")
    .WithDataVolume("redis-data");

builder.AddProject<Andromede_Srcs_External_Authentication>("External-Bff-Authentication")
    .WithReference(redis);

builder.AddProject<Andromede_Srcs_Internals_Users>("Internal-Api-Users")
    .WithReference(redis)
    .WithReference(sqlServerDatabase);

builder.AddProject<Andromede_Srcs_Services_Logging>("Internal-Service-Logging")
    .WithReference(sqlServer);

builder.AddProject<Andromede_Srcs_Services_Mailling>("Internal-Service-Mailling");

builder.Build().Run();