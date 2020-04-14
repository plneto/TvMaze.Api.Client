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

        public async Task<IEnumerable<ShowSearchResult>> ShowSearchAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentNullException(nameof(query));
            }

            var httpResponse = await _httpClient.GetAsync($"search/shows?q={query}");

            httpResponse.EnsureSuccessStatusCode();

            var jsonResponse = await httpResponse.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<ShowSearchResult>>(jsonResponse);
        }

        public async Task<IEnumerable<Episode>> GetEpisodeListAsync(int showId)
        {
            if (showId <= 0)
            {
                throw new ArgumentNullException(nameof(showId));
            }

            var httpResponse = await _httpClient.GetAsync($"shows/{showId}/episodes");

            httpResponse.EnsureSuccessStatusCode();

            var jsonResponse = await httpResponse.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<Episode>>(jsonResponse);
        }

        public async Task<Episode> GetEpisodeByNumberAsync(int showId, int season, int episodeNumber)
        {
            if (showId <= 0)
            {
                throw new ArgumentNullException(nameof(showId));
            }

            if (season <= 0)
            {
                throw new ArgumentNullException(nameof(season));
            }

            if (episodeNumber <= 0)
            {
                throw new ArgumentNullException(nameof(episodeNumber));
            }

            var httpResponse = await _httpClient.GetAsync($"shows/{showId}/episodebynumber?season={season}&number={episodeNumber}");

            httpResponse.EnsureSuccessStatusCode();

            var jsonResponse = await httpResponse.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Episode>(jsonResponse);
        }

        public async Task<Episode> GetEpisodeByIdAsync(int episodeId)
        {
            if (episodeId <= 0)
            {
                throw new ArgumentNullException(nameof(episodeId));
            }

            var httpResponse = await _httpClient.GetAsync($"episodes/{episodeId}");

            httpResponse.EnsureSuccessStatusCode();

            var jsonResponse = await httpResponse.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Episode>(jsonResponse);
        }
    }
}