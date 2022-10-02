using System.Text.Json.Serialization;

namespace TVMazeIntegration.API.Responses;

public record ShowDTO {

    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("image")]
    public Image Image { get; init; }

    [JsonPropertyName("genres")]
    public IReadOnlyCollection<string> Genres { get; set; }

    [JsonPropertyName("premiered")]
    public DateTime? Premiered { get; init; }

    [JsonPropertyName("ended")]
    public DateTime? Ended { get; init; }

    public ShowDTO(int id, string name, Image image, IReadOnlyCollection<string> genres, DateTime? premiered, DateTime? ended) {
        Id = id;
        Name = name;
        Image = image;
        Genres = genres;
        Premiered = premiered;
        Ended = ended;
    }

}