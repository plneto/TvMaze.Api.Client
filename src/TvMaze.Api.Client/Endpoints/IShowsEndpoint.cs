using System.Collections.Generic;
using System.Threading.Tasks;
using TvMaze.Api.Client.Models;

namespace TvMaze.Api.Client.Endpoints
{
    public interface IShowsEndpoint
    {
        Task<IEnumerable<Episode>> GetEpisodeListAsync(int showId);

        Task<Episode> GetEpisodeByNumberAsync(int showId, int season, int episodeNumber);
    }
}