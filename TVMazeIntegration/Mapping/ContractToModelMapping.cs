using TVMazeIntegration.API.Responses;
using TVMazeIntegration.Models;

namespace TVMazeIntegration.Mapping;

internal static class ContractToModelMapping {

    public static Show ToShow(this ShowDTO dto) {
        var imageUrl = dto.Image?.Medium ?? "";
        return new(dto.Id, dto.Name, imageUrl, dto.Genres, dto.Premiered, dto.Ended);
    }

    public static Episode ToEpisode(this EpisodeDTO dto) {
        return new(dto.Season, dto.Number, dto.Name);
    }

}
