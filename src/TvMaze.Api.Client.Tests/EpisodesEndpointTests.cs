using System;
using System.Net;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Flurl.Http.Testing;
using TvMaze.Api.Client.Models;
using Xunit;

namespace TvMaze.Api.Client.Tests
{
    public class EpisodesEndpointTests : IDisposable
    {
        private readonly Fixture _fixture;
        private readonly HttpTest _httpTest;
        private readonly ITvMazeClient _tvMazeClient;

        public EpisodesEndpointTests()
        {
            _fixture = new Fixture();
            _httpTest = new HttpTest();
            _tvMazeClient = new TvMazeClient();
        }

        [Fact]
        public async void GetEpisodeByIdAsync_ValidId_CallsCorrectUrl()
        {
            // arrange
            var episodeId = _fixture.Create<int>();

            // act
            await _tvMazeClient.Episodes.GetEpisodeMainInformationAsync(episodeId);

            // assert
            _httpTest.ShouldHaveCalled($"*/episodes/{episodeId}");
        }

        [Fact]
        public async void GetEpisodeByIdAsync_ValidId_ReturnsExpectedEpisode()
        {
            // arrange
            var episodeId = _fixture.Create<int>();
            var expectedEpisode = _fixture.Create<Episode>();

            _httpTest.RespondWithJson(expectedEpisode, (int)HttpStatusCode.OK);

            // act
            var response = await _tvMazeClient.Episodes.GetEpisodeMainInformationAsync(episodeId);

            // assert
            response.Should().BeEquivalentTo(expectedEpisode);
        }

        [Fact]
        public async void GetEpisodeByIdAsync_ValidIdNotFound_ReturnsNull()
        {
            // arrange
            var episodeId = _fixture.Create<int>();

            _httpTest.RespondWithJson("Not Found", (int)HttpStatusCode.NotFound);

            // act
            var response = await _tvMazeClient.Episodes.GetEpisodeMainInformationAsync(episodeId);

            // assert
            response.Should().BeNull();
        }

        [Fact]
        public async void GetEpisodeByIdAsync_InvalidId_ThrowsArgumentNullException()
        {
            // arrange
            const int episodeId = 0;

            // act
            Func<Task> action = () => _tvMazeClient.Episodes.GetEpisodeMainInformationAsync(episodeId);

            // assert
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        public void Dispose()
        {
            _httpTest.Dispose();
        }
    }
}
