using Serilog.Events;
using Serilog;
using SevenWinBackend.Robot;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using SevenWinBackend.Application.Services.Data;

var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory());
builder.AddJsonFile($"appsettings.json", true, true);
builder.AddJsonFile($"appsettings.{environmentName}.json", true, true);
builder.AddEnvironmentVariables();

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Build())
    .Enrich.FromLogContext()
    .CreateLogger();

// 初始化依赖注入容器
var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddRobot();
        services.AddHostedService<RobotWorker>();
    })
    .UseSerilog(logger)
    .Build();

// 处理命令参数
if (args.Contains("data"))
{
    DatabaseService database = host.Services.GetRequiredService<DatabaseService>();
    database.Init();
    return;
}
host.Run();