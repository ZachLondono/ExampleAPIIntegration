namespace TVMazeIntegration.Models;

public record Show {
    
    public int Id { get; init; }
    
    public string Name { get; init; }

    public Show(int showId, string name) {
        Id = showId;
        Name = name;
    }

}