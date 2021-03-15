using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TvMaze.Api.Client.Models;

namespace TvMaze.Api.Client.Endpoints.Shows
{
    public interface IShowsEndpoint
    {
        /// <summary>
        /// Retrieve all primary information for a given show.
        ///
        /// https://www.tvmaze.com/api#show-main-information
        /// </summary>
        /// <param name="showId">The show ID</param>
        /// <returns>Return all primary information for a given show.</returns>
        Task<Show> GetShowMainInformationAsync(int showId);

        /// <summary>
        /// A complete list of episodes for the given show.
        ///
        /// https://www.tvmaze.com/api#show-episode-list
        /// </summary>
        /// <param name="showId">The show ID</param>
        /// <returns>Return a complete list of episodes for the given show.</returns>
        Task<IEnumerable<Episode>> GetShowEpisodeListAsync(int showId);

        /// <summary>
        /// Retrieve one specific episode from this show given its season number and episode number.
        ///
        /// https://www.tvmaze.com/api#episode-by-number
        /// </summary>
        /// <param name="showId">The show ID</param>
        /// <param name="season">The season number</param>
        /// <param name="episodeNumber">The episode number</param>
        /// <returns>Returns the full information for one episode.</returns>
        Task<Episode> GetEpisodeByNumberAsync(int showId, int season, int episodeNumber);

        /// <summary>
        /// Retrieve all episodes from this show that have aired on a specific date.
        /// 
        /// https://www.tvmaze.com/api#episodes-by-date
        /// </summary>
        /// <param name="showId">The show ID</param>
        /// <param name="date">The date to get the episodes for.</param>
        /// <returns>Returns the full information of all episodes aired on the given date.</returns>
        Task<IEnumerable<Episode>> GetEpisodesByDateAsync(int showId, DateTime date);

        /// <summary>
        /// A complete list of seasons for the given show.
        ///
        /// https://www.tvmaze.com/api#show-seasons
        /// </summary>
        /// <param name="showId">The show ID</param>
        /// <returns>Returns a list of seasons.</returns>
        Task<IEnumerable<Season>> GetShowSeasonsAsync(int showId);

        /// <summary>
        /// A list of episodes in this season.
        ///
        /// https://www.tvmaze.com/api#season-episodes
        /// </summary>
        /// <param name="seasonId">The season ID</param>
        /// <returns>Returns a list of episodes in this season.</returns>
        Task<IEnumerable<Episode>> GetSeasonEpisodesAsync(int seasonId);

        /// <summary>
        /// Gets the show cast.
        ///
        /// https://www.tvmaze.com/api#show-cast
        /// </summary>
        /// <param name="showId">The show ID.</param>
        /// <returns>Returns a list of cast members.</returns>
        Task<IEnumerable<Cast>> GetShowCastAsync(int showId);

        /// <summary>
        /// Gets the show crew.
        ///
        /// https://www.tvmaze.com/api#show-crew
        /// </summary>
        /// <param name="showId">The show ID.</param>
        /// <returns>Returns a list of crew members.</returns>
        Task<IEnumerable<Crew>> GetShowCrewAsync(int showId);

        /// <summary>
        /// Gets the show images.
        ///
        /// https://www.tvmaze.com/api#show-image
        /// </summary>
        /// <param name="showId">The show ID.</param>
        /// <returns>Returns a list of show images.</returns>
        Task<IEnumerable<ShowImage>> GetShowImagesAsync(int showId);
    }
}