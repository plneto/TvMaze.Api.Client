using Newtonsoft.Json;

namespace TvMaze.Api.Client.Models
{
    public class Links
    {
        public Self Self { get; set; }

        [JsonProperty("previousepisode")]
        public PreviousEpisode PreviousEpisode { get; set; }

        [JsonProperty("nextepisode")]
        public NextEpisode NextEpisode { get; set; }
    }
}
