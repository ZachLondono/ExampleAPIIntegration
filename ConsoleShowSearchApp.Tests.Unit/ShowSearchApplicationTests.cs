using ConsoleShowSearchApp.Output;
using NSubstitute;
using TVMazeIntegration;
using TVMazeIntegration.Models;
using TVMazeIntegration.Models.Results;
using TVMazeIntegration.Services;

namespace ConsoleShowSearchApp.Tests.Unit;

public class ShowSearchApplicationTests {

    private readonly ShowSearchApplication _sut;
    private readonly IConsoleWriter _consoleWriter = Substitute.For<IConsoleWriter>();
    private readonly IShowSearchService _searcher = Substitute.For<IShowSearchService>();

    public ShowSearchApplicationTests() {
        _sut = new(_consoleWriter, _searcher);
    }

    [Fact]
    public async Task RunAsync_ShouldWriteShowsToConsole_WhenArgumentsAreValidShowQuery() {

        // Arrange
        const string query = "query";

        var show = new Show(1, "Show A");
        var shows = new List<Show>() { show };
        var searchResult = new Either<SearchByNameResult, ShowSearchError>(new SearchByNameResult(shows));
        _searcher.SearchByNameAsync(new(query)).Returns(searchResult);

        string[] args = new string[] { "-q", query };

        // Act
        await _sut.RunAsync(args);

        // Assert
        _consoleWriter.Received().WriteLine($"Found 1 shows");
        _consoleWriter.Received().WriteLine($"{show.Name}  |   {show.Id}");

    }

    [Fact]
    public async Task RunAsync_ShouldWriteErrorsToConsole_WhenArgumentsAreInvalidShowQuery() {

        // Arrange
        const string query = "";

        var message = "error message";
        var searchResult = new Either<SearchByNameResult, ShowSearchError>(new ShowSearchError(message));
        _searcher.SearchByNameAsync(new(query)).Returns(searchResult);

        string[] args = new string[] { "-q", query };

        // Act
        await _sut.RunAsync(args);

        // Assert
        _consoleWriter.Received().WriteLine(message);

    }

    [Fact]
    public async Task RunAsync_ShouldWriteEpisodesToConsole_WhenArgumentsAreValidShowId() {

        // Arrange
        const int showId = 1;

        var episode = new Episode(1, 1, "Show A");
        var episodes = new List<Episode>() { episode };
        var searchResult = new Either<ListEpisodesByShowIdResult, ShowSearchError>(new ListEpisodesByShowIdResult(episodes));
        _searcher.ListEpisodesByShowIdAsync(new(showId)).Returns(searchResult);

        string[] args = new string[] { "-e", showId.ToString()};

        // Act
        await _sut.RunAsync(args);

        // Assert
        _consoleWriter.Received().WriteLine($"Found 1 episodes");
        _consoleWriter.Received().WriteLine($"{episode.NumberInSeason}  |   {episode.Season}    |   {episode.Name}");

    }

    [Fact]
    public async Task RunAsync_ShouldWriteErrorsToConsole_WhenArgumentsAreInvalidShowId() {

        // Arrange
        const int showId = 1;

        var message = "error message";
        var searchResult = new Either<ListEpisodesByShowIdResult, ShowSearchError>(new ShowSearchError(message));
        _searcher.ListEpisodesByShowIdAsync(new(showId)).Returns(searchResult);

        string[] args = new string[] { "-e", showId.ToString() };

        // Act
        await _sut.RunAsync(args);

        // Assert
        _consoleWriter.Received().WriteLine(message);

    }

}