using System.Net.Http;
using TmEssentials;

namespace TrackManiaMiniGameBlazor.TmExchangeApi
{
    public class TrackmaniaIoApiCaller
    {
        private static readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("https://trackmania.io"),
        };

        public async Task<TrackManiaMapLeaderboardModel> GetMapLeaderboard(string mapUid)
        {
            HttpClientHelpers.AddUserAgent(_httpClient);
            var url = $"/api/leaderboard/map/{mapUid}";

            var jsonResponds = await _httpClient.GetStringAsync(url);

            return TrackManiaMapLeaderboardModel.FromJson(jsonResponds);
        }
    }
}
