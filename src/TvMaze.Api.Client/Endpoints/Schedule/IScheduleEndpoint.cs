using System.Collections.Generic;
using System.Threading.Tasks;
using TvMaze.Api.Client.Models;

namespace TvMaze.Api.Client.Endpoints.Episodes
{
    public interface IScheduleEndpoint
    {
        /// <summary>
        /// The full schedule is a list of all future episodes known to TVmaze, regardless of their country.
        /// Be advised that this endpoint's response is at least several MB large. As opposed to the other endpoints, results are cached for 24 hours.
        ///
        /// https://api.tvmaze.com/schedule/full
        /// </summary>
        /// <returns>Returns list of episodes</returns>
        Task<IEnumerable<Episode>> GetFullSchedule();
    }
}