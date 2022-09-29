using CommandLine;
using TVMazeIntegration.Models;
using TVMazeIntegration.Options;
using TVMazeIntegration.Services;
using TVMazeIntegration.Validation;

namespace TVMazeIntegration;

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
        var request = new ShowEpisodeRequest(showId);
        var result = await _searcher.SearchShowEpisodes(request);

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
        var request = new ShowSearchRequest(query);
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

    private void WriteEpisodeResults(EpisodeSearchResult result) {
        _consoleWriter.WriteLine($"Found {result.Episodes.Count} episodes");
        foreach (var episode in result.Episodes) {
            _consoleWriter.WriteLine($"{episode.Number}  |   {episode.Season}    |   {episode.Name}");
        }
    }

    private void WriteShowResults(ShowSearchResult result) {
        _consoleWriter.WriteLine($"Found {result.Shows.Count} shows");
        foreach (var show in result.Shows) {
            _consoleWriter.WriteLine($"{show.Name}  |   {show.ShowId}");
        }
    }

    private void WriteErrors(ShowSearchError error) {
        _consoleWriter.WriteLine(error.Reason);
    }

}
