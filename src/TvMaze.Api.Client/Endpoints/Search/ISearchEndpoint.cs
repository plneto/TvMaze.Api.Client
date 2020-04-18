using System.Collections.Generic;
using System.Threading.Tasks;
using TvMaze.Api.Client.Models;

namespace TvMaze.Api.Client.Endpoints.Search
{
    public interface ISearchEndpoint
    {
        /// <summary>
        /// Search through all the shows in the TVmaze database by the show's name.
        ///
        /// https://www.tvmaze.com/api#show-search
        /// </summary>
        /// <param name="query">The show's name</param>
        /// <returns>Returns a list of shows.</returns>
        Task<IEnumerable<ShowSearchResult>> ShowSearchAsync(string query);

        /// <summary>
        /// Search through all the shows in the TVmaze database by the show's
        /// name and returns one result, or no result at all.
        ///
        /// https://www.tvmaze.com/api#show-single-search
        /// </summary>
        /// <param name="query">The show's name</param>
        /// <returns>Returns exactly one result, or no result at all.</returns>
        Task<ShowSearchResult> ShowSingleSearchAsync(string query);
    }
}
