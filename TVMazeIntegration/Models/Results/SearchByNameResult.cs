namespace TVMazeIntegration.Models.Results;

internal record SearchByNameResult {

    public IReadOnlyList<Show> Shows { get; init; }

    public SearchByNameResult(IReadOnlyList<Show> shows) {
        Shows = shows;
    }

}