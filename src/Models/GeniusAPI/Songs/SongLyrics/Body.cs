using System.Text.Json.Serialization;

namespace LyricsApp.Models.GeniusAPI.Songs.SongLyrics
{
    public class Body
    {
        [JsonPropertyName("html")]
        public string Lyric { get; set; }
    }
}
