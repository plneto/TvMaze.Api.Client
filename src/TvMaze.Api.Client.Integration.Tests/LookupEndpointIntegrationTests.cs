using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace TvMaze.Api.Client.Integration.Tests
{
    public class LookupEndpointIntegrationTests
    {
        private readonly ITvMazeClient _tvMazeClient;

        public LookupEndpointIntegrationTests()
        {
            _tvMazeClient = new TvMazeClient();
        }

        [Fact]
        public async void GetLookupByTvRageId_ValidParameter_Success()
        {
            // arrange
            // Maps to tvmaze id 1
            const int tvRageId = 25988;
            
            // act 
            var response = await _tvMazeClient.Lookup.GetShowByTvRageId(tvRageId);
            
            // assert
            response.Should().NotBeNull();
        }
        
        [Fact]
        public async void GetLookupByTvRageId_InvalidId_ThrowsArgumentNullException()
        {
            // arrange
            const int tvRageId = 0;

            // act
            Func<Task> action = () => _tvMazeClient.Lookup.GetShowByTvRageId(tvRageId);

            // assert
            await action.Should().ThrowAsync<ArgumentNullException>();
        }
        
        [Fact]
        public async void GetLookupByTheTvdbId_ValidParameter_Success()
        {
            // arrange
            const int theTvdbId = 264492;
            
            // act 
            var response = await _tvMazeClient.Lookup.GetShowByTheTvdbId(theTvdbId);
            
            // assert
            response.Should().NotBeNull();
        }
        
        [Fact]
        public async void GetLookupByTheTvdbId_InvalidId_ThrowsArgumentNullException()
        {
            // arrange
            const int theTvdbId = 0;

            // act
            Func<Task> action = () => _tvMazeClient.Lookup.GetShowByTheTvdbId(theTvdbId);

            // assert
            await action.Should().ThrowAsync<ArgumentNullException>();
        }
        
        [Fact]
        public async void GetLookupByImdbId_ValidParameter_Success()
        {
            // arrange
            const string imdbId = "tt1553656";
            
            // act 
            var response = await _tvMazeClient.Lookup.GetShowByImdbId(imdbId);
            
            // assert
            response.Should().NotBeNull();
        }
        
        [Fact]
        public async void GetLookupByImdbId_InvalidId_ThrowsArgumentNullException()
        {
            // arrange
            const string imdbId = null;

            // act
            Func<Task> action = () => _tvMazeClient.Lookup.GetShowByImdbId(imdbId);

            // assert
            await action.Should().ThrowAsync<ArgumentNullException>();
        }
    }
}