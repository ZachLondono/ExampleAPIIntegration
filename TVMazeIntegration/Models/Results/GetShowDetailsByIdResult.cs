namespace TVMazeIntegration.Models.Results;

public record GetShowDetailsByIdResult {

    public Show Show { get; init; }

    public GetShowDetailsByIdResult(Show show) {
        Show = show;
    }

}