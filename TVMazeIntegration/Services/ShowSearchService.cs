using FluentValidation;
using TVMazeIntegration.API;
using TVMazeIntegration.API.Responses;
using TVMazeIntegration.Mapping;
using TVMazeIntegration.Models;
using TVMazeIntegration.Models.Requests;
using TVMazeIntegration.Models.Results;

namespace TVMazeIntegration.Services;

internal class ShowSearchService : IShowSearchService {

    private readonly ITVMazeAPI _tvShowApi;
    private readonly IValidator<SearchByNameRequest> _searchRequestValidator;
    private readonly IValidator<ListEpisodesByShowIdRequest> _episodeRequestValidator;
    private readonly IValidator<GetShowDetailsByIdRequest> _showRequestValidator;

    public ShowSearchService(ITVMazeAPI tvShowApi,
                            IValidator<SearchByNameRequest> searchValidator,
                            IValidator<ListEpisodesByShowIdRequest> episodeValidator,
                            IValidator<GetShowDetailsByIdRequest> showValidator) {
        _tvShowApi = tvShowApi;
        _searchRequestValidator = searchValidator;
        _episodeRequestValidator = episodeValidator;
        _showRequestValidator = showValidator;
    }

    public async Task<Either<SearchByNameResult, ShowSearchError>> SearchByNameAsync(SearchByNameRequest query) {

        var validationResult = _searchRequestValidator.Validate(query);
        if (!validationResult.IsValid) {
            var message = string.Join(",", validationResult.Errors);
            var searchError = new ShowSearchError(message);
            return new(searchError);
        }

        IReadOnlyCollection<SearchResult> response;
        
        try { 
            
            response = await _tvShowApi.Search(query.Query);

        } catch (Exception ex) {

            var apiError = new ShowSearchError(ex.Message);
            return new(apiError);

        }

        var shows = response.Select(r => r.Show.ToShow())
                            .ToList();

        var searchResult = new SearchByNameResult(shows);

        return new(searchResult);

    }

    public async Task<Either<ListEpisodesByShowIdResult, ShowSearchError>> ListEpisodesByShowIdAsync(ListEpisodesByShowIdRequest episodeRequest) {

        var validationResult = _episodeRequestValidator.Validate(episodeRequest);
        if (!validationResult.IsValid) {
            var message = string.Join(",", validationResult.Errors);
            var searchError = new ShowSearchError(message);
            return new(searchError);
        }

        IReadOnlyCollection<EpisodeDTO> response;

        try {
    
            response = await _tvShowApi.Episodes(episodeRequest.ShowId);

        } catch (Exception ex) {

            var apiError = new ShowSearchError(ex.Message);
            return new(apiError);

        }

        var episodes = response.Select(e => e.ToEpisode())
                                .ToList();

        var searchResult = new ListEpisodesByShowIdResult(episodes);

        return new(searchResult);

    }

    public async Task<Either<GetShowDetailsByIdResult, ShowSearchError>> GetShowDetailsById(GetShowDetailsByIdRequest showRequest) {
        
        var validationResult = _showRequestValidator.Validate(showRequest);
        if (!validationResult.IsValid) {
            var message = string.Join(",", validationResult.Errors);
            var searchError = new ShowSearchError(message);
            return new(searchError);
        }

        ShowDTO response;

        try {

            response = await _tvShowApi.ShowDetails(showRequest.ShowId);

        } catch (Exception ex) {

            var apiError = new ShowSearchError(ex.Message);
            return new(apiError);

        }

        var result = new GetShowDetailsByIdResult(response.ToShow());

        return new(result);

    }
}