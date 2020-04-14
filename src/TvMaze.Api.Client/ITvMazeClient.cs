using TvMaze.Api.Client.Endpoints;

namespace TvMaze.Api.Client
{
    public interface ITvMazeClient : ISearchEndpoint, IShowsEndpoint, IEpisodesEndpoint
    {
    }
}
