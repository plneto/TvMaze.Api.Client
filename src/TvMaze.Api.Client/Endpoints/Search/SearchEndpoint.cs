using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TvMaze.Api.Client.Models;

namespace TvMaze.Api.Client.Endpoints.Search
{
    public class SearchEndpoint : ISearchEndpoint
    {
        private readonly TvMazeHttpClient _httpClient;

        public SearchEndpoint(TvMazeHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <inheritdoc />
        public Task<IEnumerable<ShowSearchResult>> ShowSearchAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentNullException(nameof(query));
            }

            return _httpClient.GetAsync<IEnumerable<ShowSearchResult>>($"search/shows?q={query}");
        }

        /// <inheritdoc />
        public Task<ShowSearchResult> ShowSingleSearchAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentNullException(nameof(query));
            }

            return _httpClient.GetAsync<ShowSearchResult>($"singlesearch/shows?q={query}");
        }
    }
}