namespace TVMazeIntegration.Models.Requests;

public record SearchByNameRequest {

    public string Query { get; init; }

    public SearchByNameRequest(string query) {
        Query = query;
    }

}
