using CommandLine;
using TVMazeIntegration.Models;
using TVMazeIntegration.Models.Requests;
using TVMazeIntegration.Models.Results;
using TVMazeIntegration.Services;
using ConsoleShowSearchApp.Options;
using ConsoleShowSearchApp.Output;

namespace ConsoleShowSearchApp;

internal class ShowSearchApplication {

    private readonly IConsoleWriter _consoleWriter;
    private readonly IShowSearchService _searcher;

    public ShowSearchApplication(IConsoleWriter consoleWriter, IShowSearchService searcher) {
        _consoleWriter = consoleWriter;
        _searcher = searcher;
    }

    public async Task RunAsync(string[] args) {

        await Parser
                .Default
                .ParseArguments<ShowSearchApplicationOption>(args)
                .WithParsedAsync(async option => {

                    if (option.Query is not null) {
                        await ShowSearch(option.Query);
                    } else if (option.ShowId is not null) {
                        await ShowEpisodes((int) option.ShowId);
                    }

                }); 

    }

    private async Task ShowEpisodes(int showId) {
        var request = new ListEpisodesByShowIdRequest(showId);
        var result = await _searcher.ListEpisodesByShowIdAsync(request);

        result.Match(
                (searchResult) => {
                    WriteEpisodeResults(searchResult);
                },
                (searchError) => {
                    WriteErrors(searchError);
                }
            );
    }

    private async Task ShowSearch(string query) {

        _consoleWriter.Write($"Searching for shows with '{query}' in the title");

        var request = new SearchByNameRequest(query);
        var result = await _searcher.SearchByNameAsync(request);

        result.Match(
                (searchResult) => {
                    WriteShowResults(searchResult);
                },
                (searchError) => {
                    WriteErrors(searchError);
                }
            );
    }

    private void WriteEpisodeResults(ListEpisodesByShowIdResult result) {
        _consoleWriter.WriteLine($"Found {result.Episodes.Count} episodes");
        foreach (var episode in result.Episodes) {
            _consoleWriter.WriteLine($"{episode.NumberInSeason}  |   {episode.Season}    |   {episode.Name}");
        }
    }

    private void WriteShowResults(SearchByNameResult result) {
        _consoleWriter.WriteLine($"Found {result.Shows.Count} shows");
        foreach (var show in result.Shows) {
            _consoleWriter.WriteLine($"{show.Name}  |   {show.Id}");
        }
    }

    private void WriteErrors(ShowSearchError error) {
        _consoleWriter.WriteLine(error.Reason);
    }

}
