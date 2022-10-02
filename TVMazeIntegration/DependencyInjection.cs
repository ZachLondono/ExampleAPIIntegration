using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System.Runtime.CompilerServices;
using TVMazeIntegration.API;
using TVMazeIntegration.Models.Requests;
using TVMazeIntegration.Services;
using TVMazeIntegration.Validation;

[assembly: InternalsVisibleTo("TVMazeIntegration.Tests.Unit")]

namespace TVMazeIntegration;


public static class DependencyInjection {

    public static IServiceCollection AddTVMazeIntegration(this IServiceCollection services, IConfiguration configuration) {
        services.AddSingleton<IShowSearchService, ShowSearchService>();
        services.AddSingleton<IValidator<SearchByNameRequest>, SearchByNameRequestValidator>();
        services.AddSingleton<IValidator<ListEpisodesByShowIdRequest>, ListEpisodesByShowIdRequestValidator>();
        services.AddSingleton<IValidator<GetShowDetailsByIdRequest>, GetShowDetailsByIdRequestValidator>();
        services.AddRefitClient<ITVMazeAPI>()
                    .ConfigureHttpClient(c => {
                        c.BaseAddress = new(configuration["BaseUrl"]);
                    });
        return services;
    }

}
