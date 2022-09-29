using TVMazeIntegration.Models;

namespace TVMazeIntegration.Services;

internal interface IShowSearchService {

    public Task<Either<ShowSearchResult, ShowSearchError>> SearchByNameAsync(ShowSearchRequest query);

    public Task<Either<EpisodeSearchResult, ShowSearchError>> SearchShowEpisodes(ShowEpisodeRequest showId);

}