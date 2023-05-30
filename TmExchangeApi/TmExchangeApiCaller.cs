using System.Text.Json;

namespace TrackManiaMiniGameBlazor.TmExchangeApi
{
    public class TmExchangeApiCaller
    {
        private static readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("https://trackmania.exchange"),
        };

        public async Task<MapDataModel?> GetMapData(long trackId)
        {
            HttpClientHelpers.AddUserAgent(_httpClient);
            using HttpResponseMessage response = await _httpClient.GetAsync($"/api/maps/get_map_info/id/{trackId}");

            response.EnsureSuccessStatusCode();

            var mapDataModel = await response.Content.ReadFromJsonAsync<MapDataModel>();

            return mapDataModel;
        }

        public async Task GetMapPacksMapData()
        {
            var mapPackIds = new List<long>()
            {
                42,
                162,
                314,
                467,
                655,
                918,
                1179,
                1453,
                1751,
                1981,
                2330,
                2811,
            };

            var mapIdList = new List<long>();
            foreach (var mapPackId in mapPackIds)
            {
                HttpClientHelpers.AddUserAgent(_httpClient);
                using HttpResponseMessage response = await _httpClient.GetAsync($"/api/mappack/get_mappack_tracks/{mapPackId}");

                response.EnsureSuccessStatusCode();

                var mapDataModel = await response.Content.ReadFromJsonAsync<List<MapDataModel>>();

                if (mapDataModel != null)
                {
                    mapIdList.AddRange(mapDataModel.Select(m => m.TrackID));
                }
            }

            var dummyResult = string.Join(", ", mapIdList);
        }
    }
}
