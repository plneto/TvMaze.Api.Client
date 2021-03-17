using System;
using System.Net;
using System.Threading.Tasks;
using Flurl.Http;
using TvMaze.Api.Client.Exceptions;

namespace TvMaze.Api.Client.Configuration
{
    /// <summary>
    /// This implementation throws a <see cref="UnexpectedResponseStatusException"/>, if a rate limit is encountered.
    /// This is the default and should be used, if rate limiting should be handled outside of the library.
    /// </summary>
    public class ThrowExceptionRateLimitingStrategy : IRateLimitingStrategy
    {
        /// <inheritdoc />
        public async Task<IFlurlResponse> ExecuteAsync(Func<Task<IFlurlResponse>> action)
        {
            var response = await action();

            if (response.StatusCode == RateLimitingConstants.StatusCode)
            {
                throw new UnexpectedResponseStatusException("Reached rate limit of the API.", (HttpStatusCode) RateLimitingConstants.StatusCode);
            }

            return response;
        }
    }
}