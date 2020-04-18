using System;
using Newtonsoft.Json;

namespace TvMaze.Api.Client.Models
{
    public class Season
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public int Number { get; set; }

        public string Name { get; set; }

        public int EpisodeOrder { get; set; }

        public string PremiereDate { get; set; }

        public DateTime EndDate { get; set; }

        public Network Network { get; set; }

        public WebChannel WebChannel { get; set; }

        public Image Image { get; set; }

        public string Summary { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }
    }
}
