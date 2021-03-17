using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TvMaze.Api.Client.Models;

namespace TvMaze.Api.Client.Endpoints.Shows
{
    public class ShowsEndpoint : IShowsEndpoint
    {
        private readonly TvMazeHttpClient _httpClient;

        public ShowsEndpoint(TvMazeHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <inheritdoc />
        public Task<Show> GetShowMainInformationAsync(int showId)
        {
            if (showId <= 0)
            {
                throw new ArgumentNullException(nameof(showId));
            }

            return _httpClient.GetAsync<Show>($"shows/{showId}");
        }

        /// <inheritdoc />
        public Task<IEnumerable<Episode>> GetShowEpisodeListAsync(int showId)
        {
            if (showId <= 0)
            {
                throw new ArgumentNullException(nameof(showId));
            }

            return _httpClient.GetAsync<IEnumerable<Episode>>($"shows/{showId}/episodes");
        }

        /// <inheritdoc />
        public Task<Episode> GetEpisodeByNumberAsync(int showId, int season, int episodeNumber)
        {
            if (showId <= 0)
            {
                throw new ArgumentNullException(nameof(showId));
            }

            if (season <= 0)
            {
                throw new ArgumentNullException(nameof(season));
            }

            if (episodeNumber <= 0)
            {
                throw new ArgumentNullException(nameof(episodeNumber));
            }

            return _httpClient.GetAsync<Episode>($"shows/{showId}/episodebynumber?season={season}&number={episodeNumber}");
        }

        /// <inheritdoc />
        public Task<IEnumerable<Episode>> GetEpisodesByDateAsync(int showId, DateTime date)
        {
            if (showId <= 0)
            {
                throw new ArgumentNullException(nameof(showId));
            }

            return _httpClient.GetAsync<IEnumerable<Episode>>($"shows/{showId}/episodesbydate?date={date:yyyy-MM-dd}");
        }

        /// <inheritdoc />
        public Task<IEnumerable<Season>> GetShowSeasonsAsync(int showId)
        {
            if (showId <= 0)
            {
                throw new ArgumentNullException(nameof(showId));
            }

            return _httpClient.GetAsync<IEnumerable<Season>>($"shows/{showId}/seasons");
        }

        /// <inheritdoc />
        public Task<IEnumerable<Episode>> GetSeasonEpisodesAsync(int seasonId)
        {
            if (seasonId <= 0)
            {
                throw new ArgumentNullException(nameof(seasonId));
            }

            return _httpClient.GetAsync<IEnumerable<Episode>>($"seasons/{seasonId}/episodes");
        }

        /// <inheritdoc />
        public Task<IEnumerable<Cast>> GetShowCastAsync(int showId)
        {
            if (showId <= 0)
            {
                throw new ArgumentNullException(nameof(showId));
            }

            return _httpClient.GetAsync<IEnumerable<Cast>>($"shows/{showId}/cast");
        }

        /// <inheritdoc />
        public Task<IEnumerable<Crew>> GetShowCrewAsync(int showId)
        {
            if (showId <= 0)
            {
                throw new ArgumentNullException(nameof(showId));
            }

            return _httpClient.GetAsync<IEnumerable<Crew>>($"shows/{showId}/crew");
        }

        /// <inheritdoc />
        public Task<IEnumerable<ShowImage>> GetShowImagesAsync(int showId)
        {
            if (showId <= 0)
            {
                throw new ArgumentNullException(nameof(showId));
            }

            return _httpClient.GetAsync<IEnumerable<ShowImage>>($"shows/{showId}/images");
        }
    }
}