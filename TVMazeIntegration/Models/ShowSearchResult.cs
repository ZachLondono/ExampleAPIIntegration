namespace TVMazeIntegration.Models;

internal record ShowSearchResult {

    public IReadOnlyList<FoundShow> Shows { get; init; }

    public ShowSearchResult(IReadOnlyList<FoundShow> shows) {
        Shows = shows;
    }

}