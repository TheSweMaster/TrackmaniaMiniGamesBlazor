using System.Net.Http;

namespace TrackManiaMiniGameBlazor.TmExchangeApi
{
    public static class HttpClientHelpers
    {
        public static void AddUserAgent(HttpClient httpClient)
        {
            if (httpClient.DefaultRequestHeaders.Contains("User-Agent"))
            {
                httpClient.DefaultRequestHeaders.Remove("User-Agent");
            }

            httpClient.DefaultRequestHeaders.Add("User-Agent", "TheSweMaster#8595  Guess the map minigame");
        }
    }
}
