using System;
using System.Threading.Tasks;
using Flurl.Http;

namespace TvMaze.Api.Client.Configuration
{
    /// <summary>
    /// Implementations define, how rate limiting responses by the API should be handled.
    /// Rate limiting is described at https://www.tvmaze.com/api#rate-limiting.
    /// </summary>
    public interface IRateLimitingStrategy
    {
        /// <summary>
        /// Handler for HTTPRequests.
        /// </summary>
        /// <param name="action">The function that sends the HTTP Request.</param>
        /// <returns>The response from the API.</returns>
        Task<IFlurlResponse> ExecuteAsync(Func<Task<IFlurlResponse>> action);
    }
}