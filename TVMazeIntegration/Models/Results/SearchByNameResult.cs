namespace TVMazeIntegration.Models.Results;

public record SearchByNameResult {

    public IReadOnlyList<Show> Shows { get; init; }

    public SearchByNameResult(IReadOnlyList<Show> shows) {
        Shows = shows;
    }

}
