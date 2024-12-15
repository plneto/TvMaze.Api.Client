using System.Collections.Generic;
using System.Threading.Tasks;
using TvMaze.Api.Client.Models;

namespace TvMaze.Api.Client.Endpoints.Updates;

public interface IUpdatesEndpoint
{
    /// <summary>
    /// A list of all shows in the TVmaze database and the timestamp when they were last updated.
    ///
    /// https://www.tvmaze.com/api#show-updates
    /// </summary>
    /// <returns>Returns a list of all shows and the timestamp when they were last updated</returns>
    Task<IEnumerable<ShowLastUpdated>> GetShowUpdatesAsync();
}