using LyricsApp.Models.GeniusAPI.Search;
using LyricsApp.Models.GeniusAPI.Songs.SongLyrics;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Radzen;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace LyricsApp.Services
{
    public class GeniusApiService : IGeniusApiService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private const string baseApiUrl = "https://genius-song-lyrics1.p.rapidapi.com";

        public GeniusApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            var apiKey = _configuration["GeniusApiKey"];
            var apiHost = "genius-song-lyrics1.p.rapidapi.com";
            _httpClient.BaseAddress = new Uri(baseApiUrl);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", apiKey);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", apiHost);
        }

        public async Task<List<SongInfo>> SearchSongAsync(string query)
        {
            try
            {
                var searchUrl = $"{baseApiUrl}/search/?q={Uri.EscapeDataString(query)}&per_page=10&page=1";
                var response = await _httpClient.GetAsync(searchUrl);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var searchData = JsonSerializer.Deserialize<GeniusResponse>(responseBody, options);
                var hits = searchData?.Hits;

                var songsInfo = new List<SongInfo>();
                foreach (var hit in hits)
                {
                    var result = hit.Result;
                    songsInfo.Add(new SongInfo
                    {
                        Id = result.Id,
                        Title = result.Title,
                        Artist = result.ArtistNames,
                        Thumbnail = result.SongArtImageThumbnailUrl
                    });
                }

                return songsInfo;
            }
            catch (HttpRequestException ex)
            {
                // You might want to handle errors appropriately, e.g., logging or displaying to the user
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        public async Task<LyricsInfo> SearchLyricsAsync(int songId)
        {
            try
            {
                var searchUrl = $"{baseApiUrl}/song/lyrics/?id={songId}";
                var response = await _httpClient.GetAsync(searchUrl);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var searchData = JsonSerializer.Deserialize<LyricsResponse>(responseBody, options);
                var lyrics = searchData?.Lyrics?.LyricsBody?.Body?.Lyric;
                var title = searchData?.Lyrics?.TrackingData?.Title;
                var artist = searchData?.Lyrics?.TrackingData?.PrimaryArtist;

                var lyricsInfo = new LyricsInfo();
                lyricsInfo.Content = lyrics;
                lyricsInfo.Title = title;
                lyricsInfo.Artist = artist;

                return lyricsInfo;
            }
            catch (HttpRequestException ex)
            {
                // You might want to handle errors appropriately, e.g., logging or displaying to the user
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}
