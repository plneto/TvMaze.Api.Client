using Newtonsoft.Json;

namespace TvMaze.Api.Client.Models
{
    public class Externals
    {
        [JsonProperty("tvrage")]
        public int? TvRage { get; set; }
        
        [JsonProperty("thetvdb")]
        public int? TheTvdb { get; set; }
        
        public string Imdb { get; set; }
    }
}
