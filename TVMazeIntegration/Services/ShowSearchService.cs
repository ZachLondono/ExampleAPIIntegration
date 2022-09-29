using System.Linq;
using TVMazeIntegration.API;
using TVMazeIntegration.Mapping;
using TVMazeIntegration.Models;
using TVMazeIntegration.Validation;

namespace TVMazeIntegration.Services;

internal class ShowSearchService : IShowSearchService {

    private readonly ITVMazeAPI _tvShowApi;
    private readonly ShowSearchRequestValidator _searchValidator;
    private readonly ShowEpisodeRequestValidator _episodeValidator;

    public ShowSearchService(ITVMazeAPI tvShowApi, ShowSearchRequestValidator validator, ShowEpisodeRequestValidator episodeValidator) {
        _tvShowApi = tvShowApi;
        _searchValidator = validator;
        _episodeValidator = episodeValidator;
    }

    public async Task<Either<ShowSearchResult, ShowSearchError>> SearchByNameAsync(ShowSearchRequest query) {

        var validationResult = _searchValidator.Validate(query);
        if (!validationResult.IsValid) {
            var message = string.Join(",", validationResult.Errors);
            var searchError = new ShowSearchError(message);
            return new(searchError);
        }

        var response = await _tvShowApi.Search(query.Query);

        var shows = response.Select(s => s.ToFoundShow())
                            .ToList();

        var searchResult = new ShowSearchResult(shows);

        return new(searchResult);

    }

    public async Task<Either<EpisodeSearchResult, ShowSearchError>> SearchShowEpisodes(ShowEpisodeRequest query) {

        var validationResult = _episodeValidator.Validate(query);
        if (!validationResult.IsValid) {
            var message = string.Join(",", validationResult.Errors);
            var searchError = new ShowSearchError(message);
            return new(searchError);
        }

        var response = await _tvShowApi.Episodes(query.ShowId);

        var episodes = response.Select(s => s.ToFoundEpisode())
                                .ToList();

        var searchResult = new EpisodeSearchResult(episodes);

        return new(searchResult);

    }
}