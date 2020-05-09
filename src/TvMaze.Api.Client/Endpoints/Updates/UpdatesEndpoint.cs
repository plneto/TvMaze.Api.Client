using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TvMaze.Api.Client.Extensions;
using TvMaze.Api.Client.Models;

namespace TvMaze.Api.Client.Endpoints.Updates
{
    public class UpdatesEndpoint : IUpdatesEndpoint
    {
        private readonly HttpClient _httpClient;

        public UpdatesEndpoint(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ShowLastUpdated>> GetShowUpdatesAsync()
        {
            var result = await _httpClient.GetAsync<Dictionary<int, double>>("updates/shows");

            return result.Select(x => new ShowLastUpdated
            {
                Id = x.Key,
                Timestamp = x.Value
            });
        }
    }
}