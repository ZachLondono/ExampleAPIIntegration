using CommandLine;

namespace ConsoleShowSearchApp.Options;

internal record ShowSearchApplicationOption
{

    [Option('q', "query", Required = false, HelpText = "Provides the query to preform the search on.")]
    public string? Query { get; init; }

    [Option('e', "episodes", Required = false, HelpText = "Provides the id of the show whose episodes will be shown")]
    public int? ShowId { get; init; }

}
