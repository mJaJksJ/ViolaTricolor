using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using System.IO;
using System.Reflection;
using ViolaTricolor.Configuration;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateBootstrapLogger();

var log = Log.ForContext<Program>();

var config = Config.Load();

#region serilog configuration

var logTemplateConsole = "[{Level:u3}] <{ThreadId}> :: {Message:lj}{NewLine}{Exception}";
var logTemplateFile = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] <{ThreadId}> :: {Message:lj}{NewLine}{Exception}";

if (!Directory.Exists(config.Logger.FilePath))
{
    try
    {
        Directory.CreateDirectory(config.Logger.FilePath);
        log.Information($"Create directory {config.Logger.FilePath} for logs");
    }
    catch
    {
        log.Error($"Can't find or create directory {config.Logger.FilePath} for logs");
        return;
    }
}

builder.Host.UseSerilog((context, services, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services)
    .Enrich.FromLogContext()
    .Enrich.WithThreadId()
    .WriteTo.Console(outputTemplate: logTemplateConsole)
    .WriteTo.File(
        outputTemplate: logTemplateFile,
        path: Path.Combine(config.Logger.FilePath, config.Logger.FileName),
        shared: true,
        rollingInterval: config.Logger.RollingInterval.Value,
        fileSizeLimitBytes: config.Logger.LimitFileSize
    )
);

#endregion

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ViolaTricolor-Api",
        Version = "v1"
    });

    var executingLocation = Assembly.GetExecutingAssembly().Location;
    var xmlName = $"{Path.GetFileNameWithoutExtension(executingLocation)}.xml";
    var xmlPath = Path.Combine(Path.GetDirectoryName(executingLocation), xmlName);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

app.UseSerilogRequestLogging();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Iris-Api"); });

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
