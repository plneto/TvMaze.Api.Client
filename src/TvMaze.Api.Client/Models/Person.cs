using System;
using Newtonsoft.Json;

namespace TvMaze.Api.Client.Models
{
    public class Person
    {
        public int Id { get; set; }

        public Uri Url { get; set; }

        public string Name { get; set; }

        public Country Country { get; set; }

        public DateTime? Birthday { get; set; }

        public DateTime? Deathday { get; set; }

        public string Gender { get; set; }

        public Image Image { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }
    }
}