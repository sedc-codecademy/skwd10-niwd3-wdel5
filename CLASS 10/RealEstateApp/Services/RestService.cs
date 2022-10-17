using Newtonsoft.Json;
using RealEstateApp.Interfaces;
using System.Text;

namespace RealEstateApp.Services
{
    public class RestService : IRestService
    {
        //private readonly Uri BaseUri = new Uri("http://10.0.2.2:45642");
        private readonly Uri BaseUri = new Uri("http://20.113.106.55/");

        private readonly HttpClient _httpClient;

        public RestService()
        {
            _httpClient = new HttpClient { BaseAddress = BaseUri };
        }

        private async Task<string> GetAsync(string route)
        {
            if (IsConnected())
            {
                HttpResponseMessage response = await _httpClient.GetAsync(route);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }

                return response.StatusCode.ToString();
            }

            return string.Empty;
        }

        private async Task<string> PostAsync(string route, object body)
        {
            if (IsConnected())
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(route, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }

                return response.StatusCode.ToString();
            }

            return string.Empty;
        }

        private async Task<string> PatchAsync(string route, object body)
        {
            if (IsConnected())
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

                var response = await _httpClient.PatchAsync(route, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }

                return response.StatusCode.ToString();
            }

            return string.Empty;
        }

        private async Task<string> DeleteAsyncInternal(string route)
        {
            if (IsConnected())
            {
                var response = await _httpClient.DeleteAsync(route);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }

                return response.StatusCode.ToString();
            }

            return string.Empty;
        }

        private bool IsConnected()
        {
            return Connectivity.Current.NetworkAccess == NetworkAccess.Internet;
        }

        public async Task<T> GetAsync<T>(string route)
        {
            return JsonConvert.DeserializeObject<T>(await GetAsync(route));
        }

        public async Task<T> PostAsync<T>(string route, object body)
        {
            return JsonConvert.DeserializeObject<T>(await PostAsync(route, body));
        }

        public async Task<T> PatchAsync<T>(string route, object body)
        {
            return JsonConvert.DeserializeObject<T>(await PatchAsync(route, body));
        }

        public async Task<bool> DeleteAsync(string route)
        {
            return JsonConvert.DeserializeObject<bool>(await DeleteAsyncInternal(route));
        }
    }
}
