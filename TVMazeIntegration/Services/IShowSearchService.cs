using TVMazeIntegration.Models;
using TVMazeIntegration.Models.Requests;
using TVMazeIntegration.Models.Results;

namespace TVMazeIntegration.Services;

public interface IShowSearchService {

    public Task<Either<SearchByNameResult, ShowSearchError>> SearchByNameAsync(SearchByNameRequest query);

    public Task<Either<ListEpisodesByShowIdResult, ShowSearchError>> ListEpisodesByShowIdAsync(ListEpisodesByShowIdRequest episodeRequest);

    public Task<Either<GetShowDetailsByIdResult, ShowSearchError>> GetShowDetailsById(GetShowDetailsByIdRequest showRequest);

}