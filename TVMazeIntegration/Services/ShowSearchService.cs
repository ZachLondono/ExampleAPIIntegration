using Refit;
using TVMazeIntegration.API;
using TVMazeIntegration.API.Responses;
using TVMazeIntegration.Mapping;
using TVMazeIntegration.Models;
using TVMazeIntegration.Models.Requests;
using TVMazeIntegration.Models.Results;
using TVMazeIntegration.Validation;

namespace TVMazeIntegration.Services;

internal class ShowSearchService : IShowSearchService {

    private readonly ITVMazeAPI _tvShowApi;
    private readonly SearchByNameRequestValidator _searchValidator;
    private readonly ListEpisodesByShowIdRequestValidator _episodeValidator;

    public ShowSearchService(ITVMazeAPI tvShowApi, SearchByNameRequestValidator validator, ListEpisodesByShowIdRequestValidator episodeValidator) {
        _tvShowApi = tvShowApi;
        _searchValidator = validator;
        _episodeValidator = episodeValidator;
    }

    public async Task<Either<SearchByNameResult, ShowSearchError>> SearchByNameAsync(SearchByNameRequest query) {

        var validationResult = _searchValidator.Validate(query);
        if (!validationResult.IsValid) {
            var message = string.Join(",", validationResult.Errors);
            var searchError = new ShowSearchError(message);
            return new(searchError);
        }

        IReadOnlyCollection<SearchResult> response;
        
        try { 
            
            response = await _tvShowApi.Search(query.Query);

        } catch (ApiException ex) {

            var apiError = new ShowSearchError(ex.Message);
            return new(apiError);

        }

        var shows = response.Select(r => r.Show.ToShow())
                            .ToList();

        var searchResult = new SearchByNameResult(shows);

        return new(searchResult);

    }

    public async Task<Either<ListEpisodesByShowIdResult, ShowSearchError>> ListEpisodesByShowIdAsync(ListEpisodesByShowIdRequest query) {

        var validationResult = _episodeValidator.Validate(query);
        if (!validationResult.IsValid) {
            var message = string.Join(",", validationResult.Errors);
            var searchError = new ShowSearchError(message);
            return new(searchError);
        }

        IReadOnlyCollection<EpisodeDTO> response;

        try {
    
            response = await _tvShowApi.Episodes(query.ShowId);

        } catch (ApiException ex) {

            var apiError = new ShowSearchError(ex.Message);
            return new(apiError);

        }

        var episodes = response.Select(e => e.ToEpisode())
                                .ToList();

        var searchResult = new ListEpisodesByShowIdResult(episodes);

        return new(searchResult);

    }
}