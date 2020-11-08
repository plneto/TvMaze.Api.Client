using System;
using System.Net.Http;
using System.Threading.Tasks;
using TvMaze.Api.Client.Extensions;
using TvMaze.Api.Client.Models;

namespace TvMaze.Api.Client.Endpoints.Lookup
{
    public class LookupEndpoint : ILookupEndpoint
    {
        private readonly HttpClient _httpClient;

        public LookupEndpoint(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        /// <inheritdoc />
        public Task<Show> GetShowByTvRageId(int tvRageId)
        {
            if (tvRageId <= 0)
            {
                throw new ArgumentNullException(nameof(tvRageId));
            }

            return _httpClient.GetAsync<Show>($"lookup/shows?tvrage={tvRageId}");
        }

        /// <inheritdoc />
        public Task<Show> GetShowByTheTvdbId(int theTvdbId)
        {
            if (theTvdbId <= 0)
            {
                throw new ArgumentNullException(nameof(theTvdbId));
            }

            return _httpClient.GetAsync<Show>($"lookup/shows?thetvdb={theTvdbId}");
        }

        /// <inheritdoc />
        public Task<Show> GetShowByImdbId(string imdbId)
        {
            if(string.IsNullOrEmpty(imdbId))
            {
                throw new ArgumentNullException(nameof(imdbId));    
            }

            return _httpClient.GetAsync<Show>($"lookup/shows?imdb={imdbId}");
        }
    }
}