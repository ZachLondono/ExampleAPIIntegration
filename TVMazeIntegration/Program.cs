using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using TVMazeIntegration;
using TVMazeIntegration.API;
using TVMazeIntegration.Services;
using TVMazeIntegration.Validation;

[assembly: InternalsVisibleTo("TVMazeIntegration.Tests.Unit")]

var configuration = BuildConfiguration();
var serviceProvider = BuildServiceProvider(configuration);

var app = serviceProvider.GetRequiredService<ShowSearchApplication>();
await app.RunAsync(args);

static void ConfigureServices(IServiceCollection services, IConfiguration configuration) {
    services.AddSingleton<ShowSearchApplication>();
    services.AddSingleton<IShowSearchService, ShowSearchService>();
    services.AddSingleton<IConsoleWriter, ConsoleWriter>();
    services.AddSingleton<SearchByNameRequestValidator>();
    services.AddSingleton<ListEpisodesByShowIdRequestValidator>();
    services.AddRefitClient<ITVMazeAPI>()
                .ConfigureHttpClient(c => {
                    c.BaseAddress = new(configuration["BaseUrl"]);
                });
}

static ServiceProvider BuildServiceProvider(IConfiguration configuration) {
    var services = new ServiceCollection();
    ConfigureServices(services, configuration);
    return services.BuildServiceProvider();
}

static IConfiguration BuildConfiguration() => new ConfigurationBuilder()
                                            .AddJsonFile("appsettings.json")
                                            .Build();
