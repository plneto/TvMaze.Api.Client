using TvMaze.Api.Client.Endpoints.Episodes;
using TvMaze.Api.Client.Endpoints.Search;
using TvMaze.Api.Client.Endpoints.Shows;

namespace TvMaze.Api.Client
{
    public interface ITvMazeClient
    {
        ISearchEndpoint Search { get; }

        IShowsEndpoint Shows { get; }

        IEpisodesEndpoint Episodes { get; }
    }
}
