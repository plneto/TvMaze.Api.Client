using FluentAssertions;
using TvMaze.Api.Client.Configuration;
using TvMaze.Api.Client.Models;
using Xunit;

namespace TvMaze.Api.Client.Integration.Tests;

public class SearchEndpointIntegrationTests
{
    private readonly ITvMazeClient _tvMazeClient;

    public SearchEndpointIntegrationTests()
    {
        _tvMazeClient = new TvMazeClient(new HttpClient(), new RetryRateLimitingStrategy());
    }

    [Fact]
    public async Task ShowSearchAsync_ValidParameter_Success()
    {
        // arrange
        const string query = "cars";

        // act
        var response = await _tvMazeClient.Search.ShowSearchAsync(query);

        // assert
        response.Should().NotBeNull().And.NotBeEmpty();
    }

    [Fact]
    public async Task ShowSearchAsync_ValidParameter_NoResult()
    {
        // arrange
        const string query = "cars123456";

        // act
        var response = await _tvMazeClient.Search.ShowSearchAsync(query);

        // assert
        response.Should().NotBeNull().And.BeEmpty();
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public async Task ShowSearchAsync_InvalidQuery_ThrowsArgumentNullException(string query)
    {
        // act
        Func<Task> action = () => _tvMazeClient.Search.ShowSearchAsync(query);

        // assert
        await action.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task ShowSingleSearchAsync_ValidParameter_Success()
    {
        // arrange
        const string query = "girls";

        // act
        var response = await _tvMazeClient.Search.ShowSingleSearchAsync(query);

        // assert
        response.Should().NotBeNull().And.Subject.As<Show>().Id.Should().Be(139);
    }

    [Fact]
    public async Task ShowSingleSearchAsync_ValidParameter_Embed_Success()
    {
        // arrange
        const string query = "girls";

        // act
        var response = await _tvMazeClient.Search.ShowSingleSearchAsync(query, ShowEmbeddingFlags.Episodes | ShowEmbeddingFlags.Cast);

        // assert
        (response?.Embedded?.Cast).Should().NotBeNull().And.NotBeEmpty();
        (response?.Embedded?.Episodes).Should().NotBeNull().And.NotBeEmpty();
    }

    [Fact]
    public async Task ShowSingleSearchAsync_ValidParameter_NoResult()
    {
        // arrange
        const string query = "girls123456";

        // act
        var response = await _tvMazeClient.Search.ShowSingleSearchAsync(query);

        // assert
        response.Should().BeNull();
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public async Task ShowSingleSearchAsync_InvalidQuery_ThrowsArgumentNullException(string query)
    {
        // act
        Func<Task> action = () => _tvMazeClient.Search.ShowSingleSearchAsync(query);

        // assert
        await action.Should().ThrowAsync<ArgumentNullException>();
    }
}