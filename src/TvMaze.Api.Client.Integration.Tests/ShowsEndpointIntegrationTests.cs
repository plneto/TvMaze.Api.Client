using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace TvMaze.Api.Client.Integration.Tests
{
    public class ShowsEndpointIntegrationTests
    {
        private readonly ITvMazeClient _tvMazeClient;

        public ShowsEndpointIntegrationTests()
        {
            _tvMazeClient = new TvMazeClient();
        }

        [Fact]
        public async void GetEpisodeListAsync_ValidParameter_Success()
        {
            // arrange
            const int showId = 1;

            // act
            var response = await _tvMazeClient.Shows.GetShowEpisodeListAsync(showId);

            // assert
            response.Should().NotBeNull();
        }

        [Fact]
        public async void GetEpisodeListAsync_InvalidId_ThrowsArgumentNullException()
        {
            // arrange
            const int showId = 0;

            // act
            Func<Task> action = () => _tvMazeClient.Shows.GetShowEpisodeListAsync(showId);

            // assert
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async void GetEpisodeByNumberAsync_ValidParameter_Success()
        {
            // arrange
            const int showId = 1;
            const int season = 1;
            const int number = 1;

            // act
            var response = await _tvMazeClient.Shows.GetEpisodeByNumberAsync(showId, season, number);

            // assert
            response.Should().NotBeNull();
        }

        [Theory]
        [InlineData(0, 1, 1)]
        [InlineData(1, 0, 1)]
        [InlineData(1, 1, 0)]
        public async void GetEpisodeByNumberAsync_InvalidParameters_ThrowsArgumentNullException(int showId, int season, int number)
        {
            // act
            Func<Task> action = () => _tvMazeClient.Shows.GetEpisodeByNumberAsync(showId, season, number);

            // assert
            await action.Should().ThrowAsync<ArgumentNullException>();
        }
    }
}