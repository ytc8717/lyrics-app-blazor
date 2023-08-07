using System.Text.Json.Serialization;

namespace LyricsApp.Models.GeniusAPI.Songs.SongLyrics
{
    public class LyricsResponse
    {
        [JsonPropertyName("lyrics")]
        public Lyrics Lyrics { get; set; }
    }
}
