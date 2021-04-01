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
        /// <param name="embeddings">Additional information to include in the response.</param>
        /// <returns>Return all primary information for a given show.</returns>
        Task<Show> GetShowMainInformationAsync(int showId, ShowEmbeddingFlags embeddings = ShowEmbeddingFlags.None);

        /// <summary>
        /// A complete list of episodes for the given show.
        ///
        /// https://www.tvmaze.com/api#show-episode-list
        /// </summary>
        /// <param name="showId">The show ID</param>
        /// <param name="includeSpecials">Include all specials in the list of episodes.</param>
        /// <returns>Return a complete list of episodes for the given show.</returns>
        Task<IEnumerable<Episode>> GetShowEpisodeListAsync(int showId, bool includeSpecials = false);

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
        /// Gets alternative names of the show. If the Country of a alias is empty, it is an alias in the home country of the show.
        ///
        /// https://www.tvmaze.com/api#show-aka
        /// </summary>
        /// <param name="showId">The show ID.</param>
        /// <returns>Returns a list of alternative names (AKA's) for the given show.</returns>
        Task<IEnumerable<ShowAlias>> GetShowAkasAsync(int showId);

        /// <summary>
        /// Gets the show images.
        ///
        /// https://www.tvmaze.com/api#show-image
        /// </summary>
        /// <param name="showId">The show ID.</param>
        /// <returns>Returns a list of show images.</returns>
        Task<IEnumerable<ShowImage>> GetShowImagesAsync(int showId);

        /// <summary>
        /// Gets shows from the index of shows.
        /// 
        /// https://www.tvmaze.com/api#show-index
        /// </summary>
        /// <param name="page">Page of shows to get. The first page is 0.</param>
        /// <returns>The shows on the requested page of the index.</returns>
        /// <remarks>The pages are based on IDs, so you cannot rely on getting a fixed amount of episodes until you reach the end, you only know you encountered the end, if you get an empty list.</remarks>
        Task<IEnumerable<Show>> GetShowsAsync(int page);
    }
}