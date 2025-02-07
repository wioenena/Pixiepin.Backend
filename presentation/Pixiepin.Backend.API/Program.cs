using Pixiepin.Backend.API.Configurations;
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
    .ApplyCorsConfiguration()
    .ApplySerilogConfiguration()
    .AddControllers();


var app = builder.Build();

if (isDevelopment) {
    _ = app.MapOpenApi();
    _ = app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.Run();
