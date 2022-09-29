namespace TVMazeIntegration.Models;

internal record ShowEpisodeRequest {

    public int ShowId { get; init; }

    public ShowEpisodeRequest(int showId) {
        ShowId = showId;
    }

}
