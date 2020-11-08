using System;
using System.Net.Http;
using TvMaze.Api.Client.Endpoints.Episodes;
using TvMaze.Api.Client.Endpoints.Lookup;
using TvMaze.Api.Client.Endpoints.Search;
using TvMaze.Api.Client.Endpoints.Shows;
using TvMaze.Api.Client.Endpoints.Updates;

namespace TvMaze.Api.Client
{
    public class TvMazeClient : ITvMazeClient
    {
        private const string BaseApiUrl = "http://api.tvmaze.com/";

        public TvMazeClient()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseApiUrl)
            };

            Search = new SearchEndpoint(httpClient);
            Shows = new ShowsEndpoint(httpClient);
            Episodes = new EpisodesEndpoint(httpClient);
            Updates = new UpdatesEndpoint(httpClient);
            Lookup = new LookupEndpoint(httpClient);
        }

        public ISearchEndpoint Search { get; }

        public IShowsEndpoint Shows { get; }

        public IEpisodesEndpoint Episodes { get; }

        public IUpdatesEndpoint Updates { get; }
        
        public ILookupEndpoint Lookup { get; }
    }
}