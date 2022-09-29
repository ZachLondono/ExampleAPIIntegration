using System.Text.Json.Serialization;

namespace TVMazeIntegration.API.Responses;

public record EpisodeDTO {

    [JsonPropertyName("season")]
    public int Season { get; init; }

    [JsonPropertyName("number")]
    public int Number { get; init; }

    [JsonPropertyName("Name")]
    public string Name { get; init; }

    public EpisodeDTO(int season, int number, string name) {
        Season = season;
        Number = number;
        Name = name;
    }

}
