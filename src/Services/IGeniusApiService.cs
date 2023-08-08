using LyricsApp.Models;
using LyricsApp.Models.GeniusAPI.Search;
using LyricsApp.Models.GeniusAPI.Songs.SongLyrics;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LyricsApp.Services
{
    public interface IGeniusApiService
    {
        Task<List<SongInfo>> SearchSongAsync(string query);
        Task<LyricsInfo> SearchLyricsAsync(int songId);
    }
}
