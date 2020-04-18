using FluentAssertions;
using Xunit;

namespace TvMaze.Api.Client.Integration.Tests
{
    public class UpdatesEndpointIntegrationTests
    {
        private readonly ITvMazeClient _tvMazeClient;

        public UpdatesEndpointIntegrationTests()
        {
            _tvMazeClient = new TvMazeClient();
        }

        [Fact]
        public async void GetShowUpdatesAsync_Success()
        {
            var response = await _tvMazeClient.Updates.GetShowUpdatesAsync();

            response.Should().NotBeNull();
        }
    }
}
