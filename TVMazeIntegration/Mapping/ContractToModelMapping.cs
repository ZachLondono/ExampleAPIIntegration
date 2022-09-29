using TVMazeIntegration.API.Responses;
using TVMazeIntegration.Models;

namespace TVMazeIntegration.Mapping;

internal static class ContractToModelMapping {

    public static Show ToShow(this ShowDTO dto) {
        return new(dto.Id, dto.Name);
    }

    public static Episode ToEpisode(this EpisodeDTO dto) {
        return new(dto.Season, dto.Number, dto.Name);
    }

}
