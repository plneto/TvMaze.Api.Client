using System;
using System.Threading.Tasks;
using TvMaze.Api.Client.Models;

namespace TvMaze.Api.Client.Endpoints.Episodes
{
    public class EpisodesEndpoint : IEpisodesEndpoint
    {
        private readonly TvMazeHttpClient _httpClient;

        public EpisodesEndpoint(TvMazeHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <inheritdoc />
        public Task<Episode> GetEpisodeMainInformationAsync(int episodeId, EpisodeEmbeddingFlags embeddings)
        {
            if (episodeId <= 0)
            {
                throw new ArgumentException(nameof(episodeId));
            }

            return _httpClient.GetAsync<Episode>(EpisodeEmbeddings.AddQueryStringToUrl($"episodes/{episodeId}", embeddings));
        }
    }
}