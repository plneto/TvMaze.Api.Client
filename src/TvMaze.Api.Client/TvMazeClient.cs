using System.Net.Http;
using TvMaze.Api.Client.Endpoints.Episodes;
using TvMaze.Api.Client.Endpoints.Lookup;
using TvMaze.Api.Client.Endpoints.Search;
using TvMaze.Api.Client.Endpoints.Shows;
using TvMaze.Api.Client.Endpoints.Updates;
using Flurl.Http;

namespace TvMaze.Api.Client
{
    public class TvMazeClient : ITvMazeClient
    {
        private const string BaseApiUrl = "https://api.tvmaze.com/";

        public TvMazeClient()
            : this(new HttpClient())
        {
        }

        public TvMazeClient(HttpClient httpClient)
        {
            var flurlClient = new FlurlClient(httpClient);

            // Caller didn't provide the base address.
            if (flurlClient.BaseUrl == null)
            {
                flurlClient.BaseUrl = BaseApiUrl;
            }

            flurlClient.AllowAnyHttpStatus();

            var tvMazeHttpClient = new TvMazeHttpClient(flurlClient);

            Search = new SearchEndpoint(tvMazeHttpClient);
            Shows = new ShowsEndpoint(tvMazeHttpClient);
            Episodes = new EpisodesEndpoint(tvMazeHttpClient);
            Updates = new UpdatesEndpoint(tvMazeHttpClient);
            Lookup = new LookupEndpoint(tvMazeHttpClient);
        }

        public ISearchEndpoint Search { get; }

        public IShowsEndpoint Shows { get; }

        public IEpisodesEndpoint Episodes { get; }

        public IUpdatesEndpoint Updates { get; }
        
        public ILookupEndpoint Lookup { get; }
    }
}