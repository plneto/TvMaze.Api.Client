using System;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Flurl.Http.Testing;
using TvMaze.Api.Client.Configuration;
using TvMaze.Api.Client.Exceptions;
using Xunit;

namespace TvMaze.Api.Client.Tests
{
    public class RateLimitingStrategyTests : IDisposable
    {
        private readonly HttpTest _httpTest;

        public RateLimitingStrategyTests()
        {
            _httpTest = new HttpTest();
            _httpTest.RespondWith(string.Empty, RateLimitingConstants.StatusCode);
        }
        
        [Fact]
        public async void ThrowExceptionRateLimitingStrategy()
        {
            // arrange
            var strategy = new ThrowExceptionRateLimitingStrategy();
            var tvMazeClient = new TvMazeClient(new HttpClient(), strategy);
            var beforeCount = _httpTest.CallLog.Count;

            // act
            Func<Task> action = async () =>
            {
                await tvMazeClient.Shows.GetShowMainInformationAsync(1);
            };

            // assert
            await action.Should().ThrowAsync<UnexpectedResponseStatusException>();
            _httpTest.CallLog.Count.Should().Be(beforeCount + 1);
        }

        [Fact]
        public async void RetryRateLimitingStrategy()
        {
            // arrange
            const int expectedRetries = 5;
            var strategy = new RetryRateLimitingStrategy(expectedRetries, TimeSpan.FromMilliseconds(1));
            var tvMazeClient = new TvMazeClient(new HttpClient(), strategy);
            var beforeCount = _httpTest.CallLog.Count;

            // act
            Func<Task> action = async () =>
            {
                await tvMazeClient.Shows.GetShowMainInformationAsync(1);
            };

            // assert
            await action.Should().ThrowAsync<UnexpectedResponseStatusException>();
            _httpTest.CallLog.Count.Should().Be(beforeCount + expectedRetries + 1);
        }

        public void Dispose()
        {
            _httpTest?.Dispose();
        }
    }
}