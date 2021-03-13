using System.Runtime.Serialization;

namespace TvMaze.Api.Client.Models
{
    public enum EpisodeType
    {
        Regular,
        [EnumMember(Value = "significant_special")]
        SignificantSpecial,
        [EnumMember(Value = "insignificant_special")]
        InsignificantSpecial
    }
}