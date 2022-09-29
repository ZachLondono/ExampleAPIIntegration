using TVMazeIntegration.API.Responses;
using TVMazeIntegration.Models;

namespace TVMazeIntegration.Mapping;

internal static class ContractToModelMapping {

    public static FoundShow ToFoundShow(this SearchResult result) {
        return new(result.Show.Id, result.Show.Name);
    }

    public static FoundEpisode ToFoundEpisode(this EpisodeResult result) {
        return new(result.Season, result.Number, result.Name);
    }

}
