using System;
using System.Threading.Tasks;
using TvMaze.Api.Client.Models;

namespace TvMaze.Api.Client.Endpoints.Lookup
{
    public class LookupEndpoint : ILookupEndpoint
    {
        private readonly TvMazeHttpClient _httpClient;

        public LookupEndpoint(TvMazeHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <inheritdoc />
        public Task<Show> GetShowByTvRageIdAsync(int tvRageId)
        {
            if (tvRageId <= 0)
            {
                throw new ArgumentException(nameof(tvRageId));
            }

            return _httpClient.GetAsync<Show>($"lookup/shows?tvrage={tvRageId}");
        }

        /// <inheritdoc />
        public Task<Show> GetShowByTheTvdbIdAsync(int theTvdbId)
        {
            if (theTvdbId <= 0)
            {
                throw new ArgumentException(nameof(theTvdbId));
            }

            return _httpClient.GetAsync<Show>($"lookup/shows?thetvdb={theTvdbId}");
        }

        /// <inheritdoc />
        public Task<Show> GetShowByImdbIdAsync(string imdbId)
        {
            if(string.IsNullOrEmpty(imdbId))
            {
                throw new ArgumentNullException(nameof(imdbId));    
            }

            return _httpClient.GetAsync<Show>($"lookup/shows?imdb={imdbId}");
        }
    }
}