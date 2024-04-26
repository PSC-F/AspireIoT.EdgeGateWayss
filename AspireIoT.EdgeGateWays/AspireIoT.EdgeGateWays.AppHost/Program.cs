var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.AspireIoT_EdgeGateWays_ApiService>("apiservice");

builder.AddProject<Projects.AspireIoT_EdgeGateWays_Web>("webfrontend")
    .WithReference(apiService);
builder.AddProject<Projects.AspireIoT_EdgeGateWays_MonitorService>("MonitorService");
builder.Build().Run();