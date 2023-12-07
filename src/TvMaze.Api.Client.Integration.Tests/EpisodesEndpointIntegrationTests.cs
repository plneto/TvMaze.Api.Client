using System.Net.Http;
using FluentAssertions;
using TvMaze.Api.Client.Configuration;
using TvMaze.Api.Client.Models;
using Xunit;

namespace TvMaze.Api.Client.Integration.Tests;

public class EpisodesEndpointIntegrationTests
{
    private const int ValidEpisodeIdRegularType = 1;
    private const int ValidEpisodeIdSignificantSpecialType = 13961;
    private const int ValidEpisodeIdInsignificantSpecialType = 13962;

    private readonly ITvMazeClient _tvMazeClient;

    public EpisodesEndpointIntegrationTests()
    {
        _tvMazeClient = new TvMazeClient(new HttpClient(), new RetryRateLimitingStrategy());
    }

    [Theory]
    [InlineData(ValidEpisodeIdRegularType, EpisodeType.Regular)]
    [InlineData(ValidEpisodeIdSignificantSpecialType, EpisodeType.SignificantSpecial)]
    [InlineData(ValidEpisodeIdInsignificantSpecialType, EpisodeType.InsignificantSpecial)]
    public async void GetEpisodeByIdAsync_ValidParameter_Success(int episodeId, EpisodeType expectedType)
    {
        // act
        var response = await _tvMazeClient.Episodes.GetEpisodeMainInformationAsync(episodeId);

        // assert
        response.Should().NotBeNull();
        response.Type.Should().Be(expectedType);
    }

    [Fact]
    public async void GetEpisodeByIdAsync_ValidParameter_EmbeddedShow_Success()
    {
        // arrange
        const int episodeId = 1;

        // act
        var response = await _tvMazeClient.Episodes.GetEpisodeMainInformationAsync(episodeId, EpisodeEmbeddingFlags.Show);

        // assert
        (response?.Embedded?.Show).Should().NotBeNull().And.Subject.As<Show>().Id.Should().Be(1);
    }

    [Fact]
    public async void GetEpisodeByIdAsync_ValidParameter_NotFound()
    {
        // arrange
        const int episodeId = int.MaxValue;

        // act
        var response = await _tvMazeClient.Episodes.GetEpisodeMainInformationAsync(episodeId);

        // assert
        response.Should().BeNull();
    }
}