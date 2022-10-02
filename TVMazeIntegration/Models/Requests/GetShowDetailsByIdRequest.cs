namespace TVMazeIntegration.Models.Requests;

public record GetShowDetailsByIdRequest {

    public int ShowId { get; init; }

    public GetShowDetailsByIdRequest(int showId) {
        ShowId = showId;
    }

}