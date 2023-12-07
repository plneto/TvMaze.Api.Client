using System.Collections.Generic;
using System.Threading.Tasks;
using TvMaze.Api.Client.Models;

namespace TvMaze.Api.Client.Endpoints.Episodes
{
    public class ScheduleEndpoint : IScheduleEndpoint
    {
        private readonly TvMazeHttpClient _httpClient;

        public ScheduleEndpoint(TvMazeHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IEnumerable<Episode>> GetFullSchedule()
        {
            return _httpClient.GetAsync<IEnumerable<Episode>>("schedule/full");
        }
    }
}