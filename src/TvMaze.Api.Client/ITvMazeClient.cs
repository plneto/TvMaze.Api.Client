using TvMaze.Api.Client.Endpoints.Episodes;
using TvMaze.Api.Client.Endpoints.Lookup;
using TvMaze.Api.Client.Endpoints.Search;
using TvMaze.Api.Client.Endpoints.Shows;
using TvMaze.Api.Client.Endpoints.Updates;

namespace TvMaze.Api.Client;

public interface ITvMazeClient
{
    ISearchEndpoint Search { get; }

    IShowsEndpoint Shows { get; }

    IEpisodesEndpoint Episodes { get; }

    IUpdatesEndpoint Updates { get; }
        
    ILookupEndpoint Lookup { get; }
}