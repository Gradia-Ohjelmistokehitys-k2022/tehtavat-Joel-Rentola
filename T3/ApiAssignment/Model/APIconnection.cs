using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiAssignment.Model
{
    public class APIconnection
    {
        private static HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("https://api.nasa.gov/planetary/"),
        };
        public static string resData;
        private static ResultData? resultData;

        public static async Task FetchData(string request)
        {
            using HttpResponseMessage response = await _httpClient.GetAsync(request);

            var jsonResponse = await response.Content.ReadAsStringAsync();
            resultData  = JsonSerializer.Deserialize<ResultData>(jsonResponse);
            resData = jsonResponse;
        }

        public static ResultData GetData()
        {
            return resultData;
        }
    }
}
