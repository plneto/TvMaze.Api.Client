using System;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using TvMaze.Api.Client.Configuration;
using TvMaze.Api.Client.Models;
using Xunit;

namespace TvMaze.Api.Client.Integration.Tests
{
    public class ShowsEndpointIntegrationTests
    {
        private readonly ITvMazeClient _tvMazeClient;

        public ShowsEndpointIntegrationTests()
        {
            _tvMazeClient = new TvMazeClient(new HttpClient(), new RetryRateLimitingStrategy());
        }

        [Fact]
        public async void GetShowMainInformationAsync_ValidParameter_Success()
        {
            // arrange
            const int validShowId = 1;

            // act
            var response = await _tvMazeClient.Shows.GetShowMainInformationAsync(validShowId);

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
            const int notFoundShowId = int.MaxValue;

            // act
            var response = await _tvMazeClient.Shows.GetShowMainInformationAsync(notFoundShowId);

            // assert
            response.Should().BeNull();
        }

        [Fact]
        public async void GetShowMainInformationAsync_InvalidId_ThrowsArgumentException()
        {
            // arrange
            const int invalidShowId = 0;

            // act
            Func<Task> action = () => _tvMazeClient.Shows.GetShowMainInformationAsync(invalidShowId);

            // assert
            await action.Should().ThrowAsync<ArgumentException>();
        }

        [Fact]
        public async void GetEpisodeListAsync_ValidParameter_Success()
        {
            // arrange
            const int validShowId = 1;

            // act
            var response = await _tvMazeClient.Shows.GetShowEpisodeListAsync(validShowId);

            // assert
            response.Should().NotBeNull().And.NotBeEmpty().And.NotContain(episode => episode.Type != EpisodeType.Regular);
        }

        [Fact]
        public async void GetEpisodeListAsync_ValidParameter_WithSpecials_Success()
        {
            // arrange
            const int validShowId = 1;

            // act
            var response = await _tvMazeClient.Shows.GetShowEpisodeListAsync(validShowId, true);

            // assert
            response.Should().NotBeNull().And.NotBeEmpty().And.Contain(episode => episode.Type != EpisodeType.Regular);
        }

        [Fact]
        public async void GetEpisodeListAsync_ValidParameter_NotFound()
        {
            // arrange
            const int notFoundShowId = int.MaxValue;

            // act
            var response = await _tvMazeClient.Shows.GetShowEpisodeListAsync(notFoundShowId);

            // assert
            response.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async void GetEpisodeListAsync_InvalidId_ThrowsArgumentException()
        {
            // arrange
            const int invalidShowId = 0;

            // act
            Func<Task> action = () => _tvMazeClient.Shows.GetShowEpisodeListAsync(invalidShowId);

            // assert
            await action.Should().ThrowAsync<ArgumentException>();
        }

        [Fact]
        public async void GetShowSeasonsAsync_ValidParameter_Success()
        {
            // arrange
            const int validShowId = 1;

            // act
            var response = await _tvMazeClient.Shows.GetShowSeasonsAsync(validShowId);

            // assert
            response.Should().NotBeNull();
        }

        [Fact]
        public async void GetShowSeasonsAsync_ValidParameter_NotFound()
        {
            // arrange
            const int notFoundShowId = int.MaxValue;

            // act
            var response = await _tvMazeClient.Shows.GetShowSeasonsAsync(notFoundShowId);

            // assert
            response.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async void GetShowSeasonsAsync_InvalidId_ThrowsArgumentException()
        {
            // arrange
            const int invalidShowId = 0;

            // act
            Func<Task> action = () => _tvMazeClient.Shows.GetShowSeasonsAsync(invalidShowId);

            // assert
            await action.Should().ThrowAsync<ArgumentException>();
        }

        [Fact]
        public async void GetSeasonEpisodesAsync_ValidParameter_Success()
        {
            // arrange
            const int validSeasonId = 1;

            // act
            var response = await _tvMazeClient.Shows.GetSeasonEpisodesAsync(validSeasonId);

            // assert
            response.Should().NotBeNull();
        }

        [Fact]
        public async void GetSeasonEpisodesAsync_ValidParameter_NotFound()
        {
            // arrange
            const int notFoundSeasonId = int.MaxValue;

            // act
            var response = await _tvMazeClient.Shows.GetSeasonEpisodesAsync(notFoundSeasonId);

            // assert
            response.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async void GetSeasonEpisodesAsync_InvalidId_ThrowsArgumentException()
        {
            // arrange
            const int invalidSeasonId = 0;

            // act
            Func<Task> action = () => _tvMazeClient.Shows.GetSeasonEpisodesAsync(invalidSeasonId);

            // assert
            await action.Should().ThrowAsync<ArgumentException>();
        }

        [Fact]
        public async void GetEpisodeByNumberAsync_ValidParameter_Success()
        {
            // arrange
            const int validShowId = 1;
            const int validSeason = 1;
            const int validEpisodeNumber = 1;

            // act
            var response = await _tvMazeClient.Shows.GetEpisodeByNumberAsync(validShowId, validSeason, validEpisodeNumber);

            // assert
            response.Should().NotBeNull();
        }

        [Fact]
        public async void GetEpisodeByNumberAsync_ValidParameter_NotFound()
        {
            // arrange
            const int notFoundShowId = int.MaxValue;
            const int validSeason = 1;
            const int validEpisodeNumber = 1;

            // act
            var response = await _tvMazeClient.Shows.GetEpisodeByNumberAsync(notFoundShowId, validSeason, validEpisodeNumber);

            // assert
            response.Should().BeNull();
        }

        [Theory]
        [InlineData(0, 1, 1)]
        [InlineData(1, 0, 1)]
        [InlineData(1, 1, 0)]
        public async void GetEpisodeByNumberAsync_InvalidParameters_ThrowsArgumentException(int showId, int season, int number)
        {
            // act
            Func<Task> action = () => _tvMazeClient.Shows.GetEpisodeByNumberAsync(showId, season, number);

            // assert
            await action.Should().ThrowAsync<ArgumentException>();
        }

        [Fact]
        public async void GetEpisodesByDateAsync_ValidParameter_Success()
        {
            // arrange
            const int validShowId = 1;
            var validDate = new DateTime(2013, 06, 24);

            // act
            var response = await _tvMazeClient.Shows.GetEpisodesByDateAsync(validShowId, validDate);

            // assert
            response.Should().NotBeNull().And.NotBeEmpty();
        }

        [Fact]
        public async void GetEpisodesByDateAsync_ValidParameter_NoEpisodeFound()
        {
            // arrange
            const int validShowId = 1;
            var dateWithNoEpisodes = new DateTime(2013, 7, 2);

            // act
            var response = await _tvMazeClient.Shows.GetEpisodesByDateAsync(validShowId, dateWithNoEpisodes);

            // assert
            response.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async void GetEpisodesByDateAsync_InvalidId_ThrowsArgumentException()
        {
            // arrange
            const int invalidShowId = 0;
            var validDate = DateTime.Today;

            // act
            Func<Task> action = () => _tvMazeClient.Shows.GetEpisodesByDateAsync(invalidShowId, validDate);

            // assert
            await action.Should().ThrowAsync<ArgumentException>();
        }

        [Fact]
        public async void GetShowCastAsync_ValidParameters_Success()
        {
            // arrange 
            const int validShowId = 1;

            // act
            var response = await _tvMazeClient.Shows.GetShowCastAsync(validShowId);

            // assert
            response.Should().NotBeNull();
        }

        [Fact]
        public async void GetShowCastAsync_ValidParameters_NotFound()
        {
            // arrange
            const int notFoundShowId = int.MaxValue;

            // act
            var response = await _tvMazeClient.Shows.GetShowCastAsync(notFoundShowId);

            // assert
            response.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async void GetShowCastAsync_InvalidId_ThrowsArgumentException()
        {
            // arrange
            const int invalidShowId = 0;

            // act
            Func<Task> action = () => _tvMazeClient.Shows.GetShowCastAsync(invalidShowId);

            // assert
            await action.Should().ThrowAsync<ArgumentException>();
        }

        [Fact]
        public async void GetShowCrewAsync_ValidParameters_Success()
        {
            // arrange 
            const int validShowId = 1;

            // act
            var response = await _tvMazeClient.Shows.GetShowCrewAsync(validShowId);

            // assert
            response.Should().NotBeNull();
        }

        [Fact]
        public async void GetShowCrewAsync_ValidParameters_NotFound()
        {
            // arrange 
            const int notFoundShowId = int.MaxValue;

            // act
            var response = await _tvMazeClient.Shows.GetShowCrewAsync(notFoundShowId);

            // assert
            response.Should().NotBeNull();
        }

        [Fact]
        public async void GetShowCrewAsync_InvalidId_ThrowsArgumentException()
        {
            // arrange
            const int invalidShowId = 0;

            // act
            Func<Task> action = () => _tvMazeClient.Shows.GetShowCrewAsync(invalidShowId);

            // assert
            await action.Should().ThrowAsync<ArgumentException>();
        }

        [Fact]
        public async void GetShowAkas_ValidParameters_Success()
        {
            // arrange 
            const int validShowId = 1;

            // act
            var response = await _tvMazeClient.Shows.GetShowAkasAsync(validShowId);

            // assert
            response.Should().NotBeNull().And.NotBeEmpty();
        }

        [Fact]
        public async void GetShowAkas_ValidParameters_NotFound()
        {
            // arrange 
            const int notFoundShowId = int.MaxValue;

            // act
            var response = await _tvMazeClient.Shows.GetShowAkasAsync(notFoundShowId);

            // assert
            response.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async void GetShowAkas_InvalidId_ThrowsArgumentException()
        {
            // arrange
            const int invalidShowId = 0;

            // act
            Func<Task> action = () => _tvMazeClient.Shows.GetShowAkasAsync(invalidShowId);

            // assert
            await action.Should().ThrowAsync<ArgumentException>();
        }

        [Fact]
        public async void GetShowImagesAsync_ValidParameters_Success()
        {
            // arrange 
            const int validShowId = 1;

            // act
            var response = await _tvMazeClient.Shows.GetShowImagesAsync(validShowId);

            // assert
            response.Should().NotBeNull();
        }

        [Fact]
        public async void GetShowImagesAsync_ValidParameters_NotFound()
        {
            // arrange 
            const int notFoundShowId = int.MaxValue;

            // act
            var response = await _tvMazeClient.Shows.GetShowImagesAsync(notFoundShowId);

            // assert
            response.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async void GetShowImagesAsync_InvalidId_ThrowsArgumentException()
        {
            // arrange
            const int invalidShowId = 0;

            // act
            Func<Task> action = () => _tvMazeClient.Shows.GetShowImagesAsync(invalidShowId);

            // assert
            await action.Should().ThrowAsync<ArgumentException>();
        }

        [Fact]
        public async void GetShowsAsync_ValidParameters_Success()
        {
            // arrange 
            const int validPage = 1;

            // act
            var response = await _tvMazeClient.Shows.GetShowsAsync(validPage);

            // assert
            response.Should().NotBeNull().And.NotBeEmpty();
        }

        [Fact]
        public async void GetShowsAsync_ValidParameters_NotFound()
        {
            // arrange 
            const int notFoundPage = int.MaxValue;

            // act
            var response = await _tvMazeClient.Shows.GetShowsAsync(notFoundPage);

            // assert
            response.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async void GetShowsAsync_InvalidPage_ThrowsArgumentException()
        {
            // arrange
            const int invalidPage = -1;

            // act
            Func<Task> action = () => _tvMazeClient.Shows.GetShowImagesAsync(invalidPage);

            // assert
            await action.Should().ThrowAsync<ArgumentException>();
        }
    }
}