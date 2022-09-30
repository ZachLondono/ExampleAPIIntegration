using FluentAssertions;
using FluentValidation;
using NSubstitute;
using NSubstitute.Core;
using NSubstitute.ExceptionExtensions;
using Refit;
using TVMazeIntegration.API;
using TVMazeIntegration.API.Responses;
using TVMazeIntegration.Models;
using TVMazeIntegration.Models.Requests;
using TVMazeIntegration.Models.Results;
using TVMazeIntegration.Services;
using TVMazeIntegration.Validation;

namespace TVMazeIntegration.Tests.Unit;

public class ShowSearchServiceTests {

    private readonly ShowSearchService _sut;
    private readonly ITVMazeAPI _tvApi = Substitute.For<ITVMazeAPI>();
    private readonly IValidator<SearchByNameRequest>  _searchRequestValidator = new SearchByNameRequestValidator();
    private readonly IValidator<ListEpisodesByShowIdRequest> _episodeRequestValidator = new ListEpisodesByShowIdRequestValidator();

    public ShowSearchServiceTests() {
        _sut = new(_tvApi, _searchRequestValidator, _episodeRequestValidator);
    }
    
    [Fact]
    public async Task SearchByNameAsync_ShouldReturnSearchByNameResult_WhenQueryIsValid() {

        // Arrange
        const string query = "Show Name";
        var request = new SearchByNameRequest(query);

        var exampleSearchResult = new SearchResult(0, new(0, "Example Show"));
        var apiResponse = new List<SearchResult>() { exampleSearchResult };
        _tvApi.Search(query).Returns(apiResponse);


        // Act
        var result = await _sut.SearchByNameAsync(request);

        // Assert
        result.AsT1.Should().NotBeNull();
        result.AsT1!.Shows.Should().Contain(s => s.Name.Equals(exampleSearchResult.Show.Name) && s.Id == exampleSearchResult.Show.Id);

    }

    [Fact]
    public async Task SearchByNameAsync_ShouldReturnSearchError_WhenQueryIsInvalid() {

        // Arrange
        const string query = "";
        var request = new SearchByNameRequest(query);

        // Act
        var result = await _sut.SearchByNameAsync(request);

        // Assert
        result.AsT2.Should().NotBeNull();
        result.AsT2!.Reason.Should().NotBeNullOrEmpty();

    }

    [Fact]
    public async Task SearchByNameAsync_ShouldReturnSearchError_WhenApiThrowsException() {

        // Arrange
        const string query = "Show Name";
        var request = new SearchByNameRequest(query);

        const string message = "Exception reason";
        _tvApi.Search(query).Throws(new Exception(message));

        // Act
        var result = await _sut.SearchByNameAsync(request);

        // Assert
        result.AsT2.Should().NotBeNull();
        result.AsT2!.Reason.Should().Be(message);
    }

    [Fact]
    public async Task ListEpisodesByShowIdAsync_ShouldReturnListEpisodesByShowIdResult_WhenShowIdIsValid() {

        // Arrange
        const int showId = 1;
        var request = new ListEpisodesByShowIdRequest(showId);

        const int season = 1;
        const int number = 2;
        const string name = "Example Episode";
        var exampleEpisode = new EpisodeDTO(season, number, name);
        var apiResponse = new List<EpisodeDTO>() { exampleEpisode };
        _tvApi.Episodes(showId).Returns(apiResponse);

        // Act
        var result = await _sut.ListEpisodesByShowIdAsync(request);

        // Assert
        result.AsT1.Should().NotBeNull();
        result.AsT1!.Episodes.Should().Contain(e => e.Season == season && e.NumberInSeason == number && e.Name.Equals(name));

    }

    [Fact]
    public async Task ListEpisodesByShowIdAsync_ShouldReturnSearchError_WhenShowIdIsInvalid() {

        // Arrange
        const int showId = 0;
        var request = new ListEpisodesByShowIdRequest(showId);

        // Act
        var result = await _sut.ListEpisodesByShowIdAsync(request);

        // Assert
        result.AsT2.Should().NotBeNull();
        result.AsT2!.Reason.Should().NotBeNullOrEmpty();

    }

    [Fact]
    public async Task ListEpisodesByShowIdAsync_ShouldReturnSearchError_WhenApiThrowsException() {

        // Arrange
        const int showId = 1;
        var request = new ListEpisodesByShowIdRequest(showId);

        const string message = "Exception reason";
        _tvApi.Episodes(showId).Throws(new Exception(message));

        // Act
        var result = await _sut.ListEpisodesByShowIdAsync(request);

        // Assert
        result.AsT2.Should().NotBeNull();
        result.AsT2!.Reason.Should().Be(message);
    }

}