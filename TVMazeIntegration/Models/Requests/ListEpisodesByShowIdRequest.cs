namespace TVMazeIntegration.Models.Requests;

internal record ListEpisodesByShowIdRequest {

    public int ShowId { get; init; }

    public ListEpisodesByShowIdRequest(int showId) {
        ShowId = showId;
    }

}
