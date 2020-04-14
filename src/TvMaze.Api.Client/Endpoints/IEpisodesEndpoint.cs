using System.Threading.Tasks;
using TvMaze.Api.Client.Models;

namespace TvMaze.Api.Client.Endpoints
{
    public interface IEpisodesEndpoint
    {
        Task<Episode> GetEpisodeByIdAsync(int episodeId);
    }
}