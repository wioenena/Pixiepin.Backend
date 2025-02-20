using System.Net;
using System.Threading.RateLimiting;
using Pixiepin.Backend.API.Configurations;
using Pixiepin.Backend.API.Middlewares;
using Pixiepin.Backend.Application;
using Pixiepin.Backend.Persistence;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
var environment = builder.Environment.EnvironmentName;
var isDevelopment = builder.Environment.IsDevelopment();

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{environment}.json", optional: true);

builder.Services.AddOpenApi();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.ApplyCorsConfiguration();
builder.Services.ApplySerilogConfiguration();
builder.Services.ApplyJWTConfiguration(isDevelopment);
builder.Services.AddLogging();
builder.Services.AddControllers();
builder.Services.AddRateLimiter(static options => {
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
    _ = options.AddPolicy("default", static httpContext => {
        var remoteIpAddress = httpContext.Connection.RemoteIpAddress;
        return remoteIpAddress is null ?
            RateLimitPartition.GetNoLimiter(IPAddress.Loopback.ToString())
            :
            RateLimitPartition.GetFixedWindowLimiter(remoteIpAddress.ToString(), _ => new FixedWindowRateLimiterOptions {
                PermitLimit = 100,
                Window = TimeSpan.FromMinutes(1)
            });
    });
});
builder.Services.AddTransient<ExceptionMiddleware>();


var app = builder.Build();

if (isDevelopment) {
    _ = app.MapOpenApi();
    _ = app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseRateLimiter();
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthentication();
app.UseAuthorization();


app.Run();
