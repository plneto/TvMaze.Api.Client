namespace TvMaze.Api.Client.Configuration
{
    /// <summary>
    /// Constants useful for all <see cref="IRateLimitingStrategy"/>s.
    /// </summary>
    public static class RateLimitingConstants
    {
        /// <summary>
        /// The status code used for rate limiting.
        /// </summary>
        public const int StatusCode = 429;
    }
}