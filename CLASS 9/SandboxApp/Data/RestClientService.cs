using Newtonsoft.Json;
using System.Text;

namespace SandboxApp.Data
{
    public class RestClientService
    {
        private readonly Uri BaseUri = new Uri("https://jsonplaceholder.typicode.com/");

        private readonly HttpClient _httpClient;

        public RestClientService()
        {
            _httpClient = new HttpClient { BaseAddress = BaseUri };
        }

        public async Task<string> GetAsync(string route)
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

        public async Task<string> PostAsync(string route, object body)
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

        public async Task<string> PatchAsync(string route, object body)
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

        public async Task<string> DeleteAsync(string route)
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
    }
}
