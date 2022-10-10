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
            HttpResponseMessage response = await _httpClient.GetAsync(route);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return response.StatusCode.ToString();
        }
    }
}
