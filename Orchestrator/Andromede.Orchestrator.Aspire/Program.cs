var builder = DistributedApplication.CreateBuilder(args);

var sqlServer = builder
    .AddSqlServer("sqlserver")
    .WithEnvironment("ACCEPT_EULA", "Y")
    .WithEnvironment("MSSQL_PID", "Developer");
    

var redis = builder
    .AddRedis("redis")
    .WithImage("redis");

builder.AddProject<Projects.Andromede_Srcs_External_Authentication>("External-Bff-Authentication")
    .WithReference(redis);

builder.AddProject<Projects.Andromede_Srcs_Internals_Users>("Internal-Api-Users")
    .WithReference(redis)
    .WithReference(sqlServer);

builder.AddProject<Projects.Andromede_Srcs_Services_Logging>("Internal-Service-Logging")
    .WithReference(sqlServer);

builder.AddProject<Projects.Andromede_Srcs_Services_Mailling>("Internal-Service-Mailling");

builder.Build().Run();