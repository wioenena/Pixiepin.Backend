using Pixiepin.Backend.API.Configurations;
using Pixiepin.Backend.Application;
using Pixiepin.Backend.Persistence;
using Pixiepin.Backend.Shared.Result;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
var environment = builder.Environment.EnvironmentName;
var isDevelopment = builder.Environment.IsDevelopment();

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{environment}.json", optional: true);

builder.Services
    .AddOpenApi()
    .AddApplicationServices()
    .AddPersistenceServices()
    .ApplyCorsConfiguration()
    .ApplySerilogConfiguration()
    .AddLogging()
    .AddControllers();


var app = builder.Build();

if (isDevelopment) {
    _ = app.MapOpenApi();
    _ = app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.MapControllers();


app.Run();
