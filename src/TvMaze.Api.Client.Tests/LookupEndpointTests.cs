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
    public class LookupEndpointTests : IDisposable
    {
        private readonly Fixture _fixture;
        private readonly HttpTest _httpTest;
        private readonly ITvMazeClient _tvMazeClient;

        public LookupEndpointTests()
        {
            _fixture = new Fixture();
            _httpTest = new HttpTest();
            _tvMazeClient = new TvMazeClient();
        }

        [Fact]
        public async void GetShowByTvRageIdAsync_ValidId_CallsCorrectUrl()
        {
            // arrange
            var tvRageId = _fixture.Create<int>();

            // act
            await _tvMazeClient.Lookup.GetShowByTvRageIdAsync(tvRageId);

            // assert
            _httpTest.ShouldHaveCalled($"*/lookup/shows?tvrage={tvRageId}");
        }

        [Fact]
        public async void GetShowByTvRageIdAsync_ValidId_ReturnsExpectedShow()
        {
            // arrange
            var tvRageId = _fixture.Create<int>();
            var expectedShow = _fixture.Build<Show>().Without(x => x.Embedded).Create();

            _httpTest.RespondWithJson(expectedShow, (int)HttpStatusCode.OK);

            // act
            var response = await _tvMazeClient.Lookup.GetShowByTvRageIdAsync(tvRageId);

            // assert
            response.Should().BeEquivalentTo(expectedShow);
        }

        [Fact]
        public async void GetShowByTvRageIdAsync_ValidIdNotFound_ReturnsNull()
        {
            // arrange
            var tvRageId = _fixture.Create<int>();

            _httpTest.RespondWithJson("Not Found", (int)HttpStatusCode.NotFound);

            // act
            var response = await _tvMazeClient.Lookup.GetShowByTvRageIdAsync(tvRageId);

            // assert
            response.Should().BeNull();
        }

        [Fact]
        public async void GetShowByTvRageIdAsync_InvalidId_ThrowsArgumentException()
        {
            // arrange
            const int invalidTvRageId = 0;

            // act
            Func<Task> action = () => _tvMazeClient.Lookup.GetShowByTvRageIdAsync(invalidTvRageId);

            // assert
            await action.Should().ThrowAsync<ArgumentException>();
        }

        [Fact]
        public async void GetLookupByTheTvdbId_InvalidId_ThrowsArgumentException()
        {
            // arrange
            const int invalidTheTvdbId = 0;

            // act
            Func<Task> action = () => _tvMazeClient.Lookup.GetShowByTheTvdbIdAsync(invalidTheTvdbId);

            // assert
            await action.Should().ThrowAsync<ArgumentException>();
        }

        [Fact]
        public async void GetLookupByImdbId_InvalidId_ThrowsArgumentNullException()
        {
            // arrange
            const string invalidImdbId = null;

            // act
            Func<Task> action = () => _tvMazeClient.Lookup.GetShowByImdbIdAsync(invalidImdbId);

            // assert
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        public void Dispose()
        {
            _httpTest.Dispose();
        }
    }
}
