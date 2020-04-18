using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace TvMaze.Api.Client.Integration.Tests
{
    public class SearchEndpointIntegrationTests
    {
        private readonly ITvMazeClient _tvMazeClient;

        public SearchEndpointIntegrationTests()
        {
            _tvMazeClient = new TvMazeClient();
        }

        [Fact]
        public async void ShowSearchAsync_ValidParameter_Success()
        {
            // arrange
            const string query = "cars";

            // act
            var response = await _tvMazeClient.Search.ShowSearchAsync(query);

            // assert
            response.Should().NotBeNull();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async void ShowSearchAsync_InvalidQuery_ThrowsArgumentNullException(string query)
        {
            // act
            Func<Task> action = () => _tvMazeClient.Search.ShowSearchAsync(query);

            // assert
            await action.Should().ThrowAsync<ArgumentNullException>();
        }
    }
}