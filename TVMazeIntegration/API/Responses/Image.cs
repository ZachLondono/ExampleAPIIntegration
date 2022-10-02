using System.Text.Json.Serialization;

namespace TVMazeIntegration.API.Responses;

public record Image {

    [JsonPropertyName("medium")]
    public string Medium { get; init; }

    [JsonPropertyName("original")]
    public string Original { get; init; }

    public Image(string medium, string original) {
        Medium = medium;
        Original = original;
    }

}