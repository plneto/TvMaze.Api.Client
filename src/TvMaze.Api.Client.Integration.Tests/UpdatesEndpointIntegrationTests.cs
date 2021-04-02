using System.Net.Http;
using FluentAssertions;
using TvMaze.Api.Client.Configuration;
using Xunit;

namespace TvMaze.Api.Client.Integration.Tests
{
    public class UpdatesEndpointIntegrationTests
    {
        private readonly ITvMazeClient _tvMazeClient;

        public UpdatesEndpointIntegrationTests()
        {
            _tvMazeClient = new TvMazeClient(new HttpClient(), new RetryRateLimitingStrategy());
        }

        [Fact]
        public async void GetShowUpdatesAsync_Success()
        {
            var response = await _tvMazeClient.Updates.GetShowUpdatesAsync();

            response.Should().NotBeNull();
        }
    }
}
