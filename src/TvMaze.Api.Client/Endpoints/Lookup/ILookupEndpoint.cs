using System.Threading.Tasks;
using TvMaze.Api.Client.Models;

namespace TvMaze.Api.Client.Endpoints.Lookup;

public interface ILookupEndpoint
{
    /// <summary>
    /// Lookup show by TVRage ID.
    ///
    /// https://www.tvmaze.com/api#show-lookup
    /// </summary>
    /// <param name="tvRageId">The TVRage ID.</param>
    /// <returns>Returns the show information.</returns>
    Task<Show?> GetShowByTvRageIdAsync(int tvRageId);

    /// <summary>
    /// Lookup show by TheTVDB ID.
    ///
    /// https://www.tvmaze.com/api#show-lookup
    /// </summary>
    /// <param name="theTvdbId">The TheTVDB ID.</param>
    /// <returns>Returns the show information.</returns>
    Task<Show?> GetShowByTheTvdbIdAsync(int theTvdbId);

    /// <summary>
    /// Lookup show by IMDB ID.
    /// </summary>
    /// <param name="imdbId">The IMDB ID.</param>
    /// <returns>Returns the show information.</returns>
    Task<Show?> GetShowByImdbIdAsync(string imdbId);
}