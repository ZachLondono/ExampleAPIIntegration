namespace TVMazeIntegration.Models;

public record Show {
    
    public int Id { get; init; }
    
    public string Name { get; init; }

    public string ImageLink { get; init; }

    public IReadOnlyCollection<string> Genres { get; init; }

    public DateTime? PremiereDate { get; init; }

    public DateTime? EndDate { get; init; }

    public Show(int showId, string name, string imageLink, IReadOnlyCollection<string> genres, DateTime? premiereDate, DateTime? endDate) {
        Id = showId;
        Name = name;
        ImageLink = imageLink;
        Genres = genres;
        PremiereDate = premiereDate;
        EndDate = endDate;
    }

}