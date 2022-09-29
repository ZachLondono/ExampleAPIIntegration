using System.Text.Json.Serialization;

namespace TVMazeIntegration.API.Responses;

public record ShowDTO {

    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }

    public ShowDTO(int id, string name) {
        Id = id;
        Name = name;
    }

}