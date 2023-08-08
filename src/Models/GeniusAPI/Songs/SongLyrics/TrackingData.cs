using System.Text.Json.Serialization;

namespace LyricsApp.Models.GeniusAPI.Songs.SongLyrics
{
    public class TrackingData
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("primary_artist")]
        public string PrimaryArtist { get; set; }
    }
}
