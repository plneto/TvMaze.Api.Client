using System;
using System.Threading.Tasks;
using Flurl.Http;
using Polly;
using TvMaze.Api.Client.Constants;

namespace TvMaze.Api.Client.Configuration;

/// <summary>
/// This implementation will retry the request multiple times, if a rate limit is encountered.
/// </summary>
public class RetryRateLimitingStrategy : IRateLimitingStrategy
{
    private const int DefaultRetries = 5;
    private static readonly TimeSpan DefaultRetryInterval = TimeSpan.FromSeconds(3);

    private readonly AsyncPolicy<IFlurlResponse> _policy;

    /// <summary>
    /// Creates an instance with reasonable default values for the rate limits described by the API.
    /// </summary>
    public RetryRateLimitingStrategy()
        : this(DefaultRetries, DefaultRetryInterval)
    {
    }

    /// <summary>
    /// Creates an instance that uses the provided configuration values for retrying.
    /// </summary>
    /// <param name="retries"></param>
    /// <param name="retryInterval"></param>
    public RetryRateLimitingStrategy(int retries, TimeSpan retryInterval)
    {
        _policy = Policy
            .HandleResult<IFlurlResponse>(response => response.StatusCode == HttpStatusCodes.TooManyAttempts)
            .WaitAndRetryAsync(retries, i => retryInterval);
    }

    /// <inheritdoc />
    public Task<IFlurlResponse> ExecuteAsync(Func<Task<IFlurlResponse>> action)
    {
        return _policy.ExecuteAsync(action);
    }
}