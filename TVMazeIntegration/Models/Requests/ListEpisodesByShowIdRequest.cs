namespace TVMazeIntegration.Models.Requests;

public record ListEpisodesByShowIdRequest {

    public int ShowId { get; init; }

    public ListEpisodesByShowIdRequest(int showId) {
        ShowId = showId;
    }

}
