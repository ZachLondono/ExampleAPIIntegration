using System.Text.Json.Serialization;

namespace TVMazeIntegration.API.Responses;

internal record Show {

    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }

    public Show(int id, string name) {
        Id = id;
        Name = name;
    }

}