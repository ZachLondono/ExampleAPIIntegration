using Refit;
using TVMazeIntegration.API.Responses;

namespace TVMazeIntegration.API;

public interface ITVMazeAPI {

    [Get("/search/shows?q={query}")]
    public Task<IReadOnlyCollection<SearchResult>> Search(string query);

    [Get("/shows/{showId}/episodes")]
    public Task<IReadOnlyCollection<EpisodeDTO>> Episodes(int showId);

}