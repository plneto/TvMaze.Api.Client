using FluentAssertions;
using TvMaze.Api.Client.Models;
using Xunit;

namespace TvMaze.Api.Client.Integration.Tests
{
    public class EpisodesEndpointIntegrationTests
    {
        private readonly ITvMazeClient _tvMazeClient;

        public EpisodesEndpointIntegrationTests()
        {
            _tvMazeClient = new TvMazeClient();
        }

        [Theory]
        [InlineData(1, EpisodeType.Regular)]
        [InlineData(13961, EpisodeType.SignificantSpecial)]
        [InlineData(13960, EpisodeType.InsignificantSpecial)]
        public async void GetEpisodeByIdAsync_ValidParameter_Success(int episodeId, EpisodeType expectedType)
        {
            // act
            var response = await _tvMazeClient.Episodes.GetEpisodeMainInformationAsync(episodeId);

            // assert
            response.Should().NotBeNull();
            response.Type.Should().BeEquivalentTo(expectedType);
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
}