using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TVMazeIntegration.API.Responses;

internal record EpisodeResult {

    [JsonPropertyName("season")]
    public int Season { get; init; }

    [JsonPropertyName("number")]
    public int Number { get; init; }

    [JsonPropertyName("Name")]
    public string Name { get; init; }

    public EpisodeResult(int season, int number, string name) {
        Season = season;
        Number = number;
        Name = name;
    }

}
