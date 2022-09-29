namespace TVMazeIntegration.Models;

internal record Episode {

    public int Season { get; init; }
    
    public int NumberInSeason { get; init; }
    
    public string Name { get; init; }

    public Episode(int season, int number, string name) {
        Season = season;
        NumberInSeason = number;
        Name = name;
    }

}