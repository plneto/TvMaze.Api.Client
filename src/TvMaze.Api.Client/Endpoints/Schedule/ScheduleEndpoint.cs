using System.Collections.Generic;
using System.Threading.Tasks;
using TvMaze.Api.Client.Models;

namespace TvMaze.Api.Client.Endpoints.Schedule;

public class ScheduleEndpoint : IScheduleEndpoint
{
    private readonly TvMazeHttpClient _httpClient;

    public ScheduleEndpoint(TvMazeHttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Episode>> GetFullSchedule()
    {
        var response = await _httpClient.GetAsync<IEnumerable<Episode>>("schedule/full");

        return response ?? [];
    }
}