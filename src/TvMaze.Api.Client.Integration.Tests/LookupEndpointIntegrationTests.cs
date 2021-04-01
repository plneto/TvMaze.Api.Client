using System.Net.Http;
using FluentAssertions;
using TvMaze.Api.Client.Configuration;
using Xunit;

namespace TvMaze.Api.Client.Integration.Tests
{
    public class LookupEndpointIntegrationTests
    {
        private readonly ITvMazeClient _tvMazeClient;

        public LookupEndpointIntegrationTests()
        {
            _tvMazeClient = new TvMazeClient(new HttpClient(), new RetryRateLimitingStrategy());
        }

        [Fact]
        public async void GetShowByTvRageIdAsync_ValidParameter_Success()
        {
            // arrange
            // Maps to tvmaze id 1
            const int tvRageId = 25988;
            
            // act 
            var response = await _tvMazeClient.Lookup.GetShowByTvRageIdAsync(tvRageId);
            
            // assert
            response.Should().NotBeNull();
        }

        [Fact]
        public async void GetShowByTvRageIdAsync_ValidParameter_NotFound()
        {
            // arrange
            const int tvRageId = int.MaxValue;

            // act 
            var response = await _tvMazeClient.Lookup.GetShowByTvRageIdAsync(tvRageId);

            // assert
            response.Should().BeNull();
        }
        
        [Fact]
        public async void GetShowByTheTvdbIdAsync_ValidParameter_Success()
        {
            // arrange
            const int theTvdbId = 264492;
            
            // act 
            var response = await _tvMazeClient.Lookup.GetShowByTheTvdbIdAsync(theTvdbId);
            
            // assert
            response.Should().NotBeNull();
        }

        [Fact]
        public async void GetShowByTheTvdbIdAsync_ValidParameter_NotFound()
        {
            // arrange
            const int theTvdbId = int.MaxValue;
            
            // act 
            var response = await _tvMazeClient.Lookup.GetShowByTheTvdbIdAsync(theTvdbId);
            
            // assert
            response.Should().BeNull();
        }
        
        [Fact]
        public async void GetShowByImdbIdAsync_ValidParameter_Success()
        {
            // arrange
            const string imdbId = "tt1553656";
            
            // act 
            var response = await _tvMazeClient.Lookup.GetShowByImdbIdAsync(imdbId);
            
            // assert
            response.Should().NotBeNull();
        }

        [Fact]
        public async void GetShowByImdbIdAsync_ValidParameter_NotFound()
        {
            // arrange
            const string imdbId = "ShouldNotExist";
            
            // act 
            var response = await _tvMazeClient.Lookup.GetShowByImdbIdAsync(imdbId);
            
            // assert
            response.Should().BeNull();
        }
    }
}