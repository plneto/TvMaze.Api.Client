using System;
using Newtonsoft.Json;

namespace TvMaze.Api.Client.Models
{
    public class Episode
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string Name { get; set; }

        public int Season { get; set; }

        public int Number { get; set; }

        [JsonProperty("airdate")]
        public string AirDate { get; set; }

        [JsonProperty("airtime")]
        public string AirTime { get; set; }

        [JsonProperty("airstamp")]
        public DateTimeOffset? AirStamp { get; set; }

        public int Runtime { get; set; }

        public Image Image { get; set; }

        public string Summary { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }
    }
}