using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TvMaze.Api.Client.Models
{
    public class Show
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Language { get; set; }

        public List<string> Genres { get; set; }

        public string Status { get; set; }

        public int? Runtime { get; set; }
        public int? AverageRuntime { get; set; }

        public DateTime? Premiered { get; set; }

        public DateTime? Ended { get; set; }

        public string OfficialSite { get; set; }

        public Schedule Schedule { get; set; }

        public Rating Rating { get; set; }

        public int Weight { get; set; }

        public Network Network { get; set; }

        public WebChannel WebChannel { get; set; }

        public Externals Externals { get; set; }

        public Image Image { get; set; }

        public string Summary { get; set; }

        public int Updated { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }

        [JsonProperty("_embedded")]
        public ShowEmbeddings Embedded { get; set; }
    }
}
