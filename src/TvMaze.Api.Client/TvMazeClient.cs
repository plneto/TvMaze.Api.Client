using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TvMaze.Api.Client.Models;

namespace TvMaze.Api.Client
{
    public class TvMazeClient : ITvMazeClient
    {
        private const string BaseApiUrl = "http://api.tvmaze.com/";

        private readonly HttpClient _httpClient;

        public TvMazeClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseApiUrl)
            };
        }

        public async Task<IEnumerable<ShowSearch>> ShowSearch(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentNullException(nameof(query));
            }

            var httpResponse = await _httpClient.GetAsync($"search/shows?q={query}");

            httpResponse.EnsureSuccessStatusCode();

            var jsonResponse = await httpResponse.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<ShowSearch>>(jsonResponse);
        }
    }
}