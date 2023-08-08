using System.Text.Json.Serialization;

namespace LyricsApp.Models.GeniusAPI.Search
{
    public class GeniusResult
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [JsonPropertyName("artist_names")]
        public string ArtistNames { get; set; }

        [JsonPropertyName("song_art_image_thumbnail_url")]
        public string SongArtImageThumbnailUrl { get; set; }
    }
}
