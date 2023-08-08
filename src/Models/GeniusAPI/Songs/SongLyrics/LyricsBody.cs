using System.Text.Json.Serialization;

namespace LyricsApp.Models.GeniusAPI.Songs.SongLyrics
{
    public class LyricsBody
    {
        [JsonPropertyName("body")]
        public Body Body { get; set; }
    }
}
