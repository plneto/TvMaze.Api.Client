using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvMaze.Api.Client.Models;

namespace TvMaze.Api.Client.Endpoints.Updates
{
    public class UpdatesEndpoint : IUpdatesEndpoint
    {
        private readonly TvMazeHttpClient _httpClient;

        public UpdatesEndpoint(TvMazeHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <inheritdoc />
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