using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ConsoleShowSearchApp;
using TVMazeIntegration;
using ConsoleShowSearchApp.Output;

[assembly: InternalsVisibleTo("ConsoleShowSearchApp.Tests.Unit")]

var configuration = BuildConfiguration();
var serviceProvider = BuildServiceProvider(configuration);

var app = serviceProvider.GetRequiredService<ShowSearchApplication>();
await app.RunAsync(args);

static ServiceProvider BuildServiceProvider(IConfiguration configuration)
    => new ServiceCollection()
            .AddSingleton<ShowSearchApplication>()
            .AddSingleton<IConsoleWriter, ConsoleWriter>()
            .AddTVMazeIntegration(configuration)
            .BuildServiceProvider();

static IConfiguration BuildConfiguration() => new ConfigurationBuilder()
                                            .AddJsonFile("appsettings.json")
                                            .Build();
