using System.Text.Json.Serialization;

namespace TVMazeIntegration.API.Responses;

internal record SearchResult {

    [JsonPropertyName("score")]
    public double Confidence { get; init; }

    [JsonPropertyName("show")]
    public ShowDTO Show { get; init; }

    public SearchResult(double confidence, ShowDTO show) {
        Confidence = confidence;
        Show = show;
    }

}
