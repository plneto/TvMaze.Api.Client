using System.Threading.Tasks;
using TvMaze.Api.Client.Models;

namespace TvMaze.Api.Client.Endpoints.Episodes
{
    public interface IEpisodesEndpoint
    {
        /// <summary>
        /// Retrieve all primary information for a given episode.
        ///
        /// https://www.tvmaze.com/api#episode-main-information
        /// </summary>
        /// <param name="episodeId">The episode ID</param>
        /// <param name="embeddings">Defines, which additional information should be returned with the request.</param>
        /// <returns>Returns the episode information</returns>
        Task<Episode> GetEpisodeMainInformationAsync(int episodeId, EpisodeEmbeddingFlags embeddings = EpisodeEmbeddingFlags.None);
    }
}