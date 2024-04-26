var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.AspireIoT_EdgeGateWays_ApiService>("apiservice");

builder.AddProject<Projects.AspireIoT_EdgeGateWays_Web>("webfrontend")
    .WithReference(apiService);

builder.Build().Run();