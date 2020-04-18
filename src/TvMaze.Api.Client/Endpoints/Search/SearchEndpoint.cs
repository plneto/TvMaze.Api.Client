using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TvMaze.Api.Client.Extensions;
using TvMaze.Api.Client.Models;

namespace TvMaze.Api.Client.Endpoints.Search
{
    public class SearchEndpoint : ISearchEndpoint
    {
        private readonly HttpClient _httpClient;

        public SearchEndpoint(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IEnumerable<ShowSearchResult>> ShowSearchAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentNullException(nameof(query));
            }

            return _httpClient.GetAsync<IEnumerable<ShowSearchResult>>($"search/shows?q={query}");
        }

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