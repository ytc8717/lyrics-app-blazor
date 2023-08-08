using System.Text.Json.Serialization;

namespace LyricsApp.Models.GeniusAPI.Songs.SongLyrics
{
    public class Lyrics
    {
        [JsonPropertyName("lyrics")]
        public LyricsBody LyricsBody { get; set; }

        [JsonPropertyName("tracking_data")]
        public TrackingData TrackingData { get; set; }
    }
}
