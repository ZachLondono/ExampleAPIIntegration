using System.Text.Json.Serialization;

namespace TVMazeIntegration.API.Responses;

internal record SearchResult {

    [JsonPropertyName("score")]
    public double Score { get; init; }

    [JsonPropertyName("show")]
    public Show Show { get; init; }

    public SearchResult(double score, Show show) {
        Score = score;
        Show = show;
    }

}
