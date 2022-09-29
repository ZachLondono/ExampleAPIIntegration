namespace TVMazeIntegration.Models.Requests;

internal record SearchByNameRequest {

    public string Query { get; init; }

    public SearchByNameRequest(string query) {
        Query = query;
    }

}