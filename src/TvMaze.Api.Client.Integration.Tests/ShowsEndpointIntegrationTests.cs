using System;
using System.Threading.Tasks;
using FluentAssertions;
using TvMaze.Api.Client.Models;
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
        public async void GetShowMainInformationAsync_ValidParameter_Success()
        {
            // arrange
            const int showId = 1;

            // act
            var response = await _tvMazeClient.Shows.GetShowMainInformationAsync(showId);

            // assert
            response.Should().NotBeNull();
        }

        [Fact]
        public async void GetShowMainInformationAsync_ValidParameter_EmbedEpisodes_Success()
        {
            // arrange
            const int showId = 1;

            // act
            var response = await _tvMazeClient.Shows.GetShowMainInformationAsync(showId, ShowEmbeddingFlags.Episodes);

            // assert
            (response?.Embedded?.Episodes).Should().NotBeNull().And.NotBeEmpty();
        }

        [Fact]
        public async void GetShowMainInformationAsync_ValidParameter_EmbedPreviousEpisode_Success()
        {
            // arrange
            const int showId = 1;

            // act
            var response = await _tvMazeClient.Shows.GetShowMainInformationAsync(showId, ShowEmbeddingFlags.PreviousEpisode);

            // assert
            (response?.Embedded?.PreviousEpisode).Should().NotBeNull();
        }

        [Fact]
        public async void GetShowMainInformationAsync_ValidParameter_EmbedCast_Success()
        {
            // arrange
            const int showId = 1;

            // act
            var response = await _tvMazeClient.Shows.GetShowMainInformationAsync(showId, ShowEmbeddingFlags.Cast);

            // assert
            (response?.Embedded?.Cast).Should().NotBeNull().And.NotBeEmpty();
        }

        [Fact]
        public async void GetShowMainInformationAsync_ValidParameter_EmbedMultiple_Success()
        {
            // arrange
            const int showId = 1;

            // act
            var response = await _tvMazeClient.Shows.GetShowMainInformationAsync(showId, ShowEmbeddingFlags.Episodes | ShowEmbeddingFlags.Cast);

            // assert
            (response?.Embedded?.Episodes).Should().NotBeNull().And.NotBeEmpty();
            (response?.Embedded?.Cast).Should().NotBeNull().And.NotBeEmpty();
        }

        [Fact]
        public async void GetShowMainInformationAsync_ValidParameter_NotFound()
        {
            // arrange
            const int showId = int.MaxValue;

            // act
            var response = await _tvMazeClient.Shows.GetShowMainInformationAsync(showId);

            // assert
            response.Should().BeNull();
        }

        [Fact]
        public async void GetShowMainInformationAsync_InvalidId_ThrowsArgumentNullException()
        {
            // arrange
            const int showId = 0;

            // act
            Func<Task> action = () => _tvMazeClient.Shows.GetShowMainInformationAsync(showId);

            // assert
            await action.Should().ThrowAsync<ArgumentNullException>();
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
        public async void GetEpisodeListAsync_ValidParameter_NotFound()
        {
            // arrange
            const int showId = int.MaxValue;

            // act
            var response = await _tvMazeClient.Shows.GetShowEpisodeListAsync(showId);

            // assert
            response.Should().NotBeNull().And.BeEmpty();
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
        public async void GetShowSeasonsAsync_ValidParameter_Success()
        {
            // arrange
            const int showId = 1;

            // act
            var response = await _tvMazeClient.Shows.GetShowSeasonsAsync(showId);

            // assert
            response.Should().NotBeNull();
        }

        [Fact]
        public async void GetShowSeasonsAsync_ValidParameter_NotFound()
        {
            // arrange
            const int showId = int.MaxValue;

            // act
            var response = await _tvMazeClient.Shows.GetShowSeasonsAsync(showId);

            // assert
            response.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async void GetShowSeasonsAsync_InvalidId_ThrowsArgumentNullException()
        {
            // arrange
            const int showId = 0;

            // act
            Func<Task> action = () => _tvMazeClient.Shows.GetShowSeasonsAsync(showId);

            // assert
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async void GetSeasonEpisodesAsync_ValidParameter_Success()
        {
            // arrange
            const int seasonId = 1;

            // act
            var response = await _tvMazeClient.Shows.GetSeasonEpisodesAsync(seasonId);

            // assert
            response.Should().NotBeNull();
        }

        [Fact]
        public async void GetSeasonEpisodesAsync_ValidParameter_NotFound()
        {
            // arrange
            const int seasonId = int.MaxValue;

            // act
            var response = await _tvMazeClient.Shows.GetSeasonEpisodesAsync(seasonId);

            // assert
            response.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async void GetSeasonEpisodesAsync_InvalidId_ThrowsArgumentNullException()
        {
            // arrange
            const int seasonId = 0;

            // act
            Func<Task> action = () => _tvMazeClient.Shows.GetSeasonEpisodesAsync(seasonId);

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

        [Fact]
        public async void GetEpisodeByNumberAsync_ValidParameter_NotFound()
        {
            // arrange
            const int showId = int.MaxValue;
            const int season = 1;
            const int number = 1;

            // act
            var response = await _tvMazeClient.Shows.GetEpisodeByNumberAsync(showId, season, number);

            // assert
            response.Should().BeNull();
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
        
        [Fact]
        public async void GetEpisodesByDate_ValidParameter_Success()
        {
            // arrange
            const int showId = 1;
            var date = new DateTime(2013, 06, 24);

            // act
            var response = await _tvMazeClient.Shows.GetEpisodesByDateAsync(showId, date);

            // assert
            response.Should().NotBeNull().And.NotBeEmpty();
        }

        [Fact]
        public async void GetEpisodesByDate_ValidParameter_NoEpisodeFound()
        {
            // arrange
            const int showId = 1;
            var date = DateTime.MinValue;

            // act
            var response = await _tvMazeClient.Shows.GetEpisodesByDateAsync(showId, date);

            // assert
            response.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async void GetEpisodesByDate_InvalidId_ThrowsArgumentNullException()
        {
            // arrange
            const int showId = 0;
            var date = DateTime.MinValue;

            // act
            Func<Task> action = () => _tvMazeClient.Shows.GetEpisodesByDateAsync(showId, date);

            // assert
            await action.Should().ThrowAsync<ArgumentException>();
        }

        [Fact]
        public async void GetShowCastAsync_ValidParameters_Success()
        {
            // arrange 
            const int showId = 1;
            
            // act
            var response = await _tvMazeClient.Shows.GetShowCastAsync(showId);

            // assert
            response.Should().NotBeNull();
        }

        [Fact]
        public async void GetShowCastAsync_ValidParameters_NotFound()
        {
            // arrange
            const int showId = int.MaxValue;

            // act
            var response = await _tvMazeClient.Shows.GetShowCastAsync(showId);

            // assert
            response.Should().NotBeNull().And.BeEmpty();
        }
        
        [Fact]
        public async void GetShowCastAsync_InvalidId_ThrowsArgumentNullException()
        {
            // arrange
            const int showId = 0;

            // act
            Func<Task> action = () => _tvMazeClient.Shows.GetShowCastAsync(showId);

            // assert
            await action.Should().ThrowAsync<ArgumentNullException>();
        }
        
        [Fact]
        public async void GetShowCrewAsync_ValidParameters_Success()
        {
            // arrange 
            const int showId = 1;
            
            // act
            var response = await _tvMazeClient.Shows.GetShowCrewAsync(showId);

            // assert
            response.Should().NotBeNull();
        }

        [Fact]
        public async void GetShowCrewAsync_ValidParameters_NotFound()
        {
            // arrange 
            const int showId = int.MaxValue;
            
            // act
            var response = await _tvMazeClient.Shows.GetShowCrewAsync(showId);

            // assert
            response.Should().NotBeNull();
        }
        
        [Fact]
        public async void GetShowCrewAsync_InvalidId_ThrowsArgumentNullException()
        {
            // arrange
            const int showId = 0;

            // act
            Func<Task> action = () => _tvMazeClient.Shows.GetShowCrewAsync(showId);

            // assert
            await action.Should().ThrowAsync<ArgumentNullException>();
        }
        
        [Fact]
        public async void GetShowImagesAsync_ValidParameters_Success()
        {
            // arrange 
            const int showId = 1;
            
            // act
            var response = await _tvMazeClient.Shows.GetShowImagesAsync(showId);

            // assert
            response.Should().NotBeNull();
        }

        [Fact]
        public async void GetShowImagesAsync_ValidParameters_NotFound()
        {
            // arrange 
            const int showId = int.MaxValue;
            
            // act
            var response = await _tvMazeClient.Shows.GetShowImagesAsync(showId);

            // assert
            response.Should().NotBeNull().And.BeEmpty();
        }
        
        [Fact]
        public async void GetShowImagesAsync_InvalidId_ThrowsArgumentNullException()
        {
            // arrange
            const int showId = 0;

            // act
            Func<Task> action = () => _tvMazeClient.Shows.GetShowImagesAsync(showId);

            // assert
            await action.Should().ThrowAsync<ArgumentNullException>();
        }
    }
}