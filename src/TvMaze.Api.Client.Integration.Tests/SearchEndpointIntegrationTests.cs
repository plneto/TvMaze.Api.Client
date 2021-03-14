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
            response.Should().NotBeNull().And.NotBeEmpty();
        }

        [Fact]
        public async void ShowSearchAsync_ValidParameter_NoResult()
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
        public async void ShowSearchAsync_InvalidQuery_ThrowsArgumentNullException(string query)
        {
            // act
            Func<Task> action = () => _tvMazeClient.Search.ShowSearchAsync(query);

            // assert
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async void ShowSingleSearchAsync_ValidParameter_Success()
        {
            // arrange
            const string query = "girls";

            // act
            var response = await _tvMazeClient.Search.ShowSingleSearchAsync(query);

            // assert
            response.Should().NotBeNull();
        }

        [Fact]
        public async void ShowSingleSearchAsync_ValidParameter_NoResult()
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
        public async void ShowSingleSearchAsync_InvalidQuery_ThrowsArgumentNullException(string query)
        {
            // act
            Func<Task> action = () => _tvMazeClient.Search.ShowSingleSearchAsync(query);

            // assert
            await action.Should().ThrowAsync<ArgumentNullException>();
        }
    }
}