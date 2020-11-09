using System;
using Newtonsoft.Json;

namespace TvMaze.Api.Client.Models
{
    public class Character
    {
        public int Id { get; set; }

        public Uri Url { get; set; }

        public string Name { get; set; }

        public Image Image { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }
    }
}