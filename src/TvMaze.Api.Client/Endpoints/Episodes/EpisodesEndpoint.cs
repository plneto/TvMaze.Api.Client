using System;
using System.Net.Http;
using System.Threading.Tasks;
using TvMaze.Api.Client.Extensions;
using TvMaze.Api.Client.Models;

namespace TvMaze.Api.Client.Endpoints.Episodes
{
    public class EpisodesEndpoint : IEpisodesEndpoint
    {
        private readonly HttpClient _httpClient;

        public EpisodesEndpoint(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<Episode> GetEpisodeMainInformationAsync(int episodeId)
        {
            if (episodeId <= 0)
            {
                throw new ArgumentNullException(nameof(episodeId));
            }

            return _httpClient.GetAsync<Episode>($"episodes/{episodeId}");
        }
    }
}