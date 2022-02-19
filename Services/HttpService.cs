using ColumbusTest.Models;
using System.Text.Json;

namespace ColumbusTest.Services
{
    public class HttpService<U>
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<U> _logger;

        public HttpService(HttpClient httpClient, ILogger<U> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<ApiResponse<T>> HttpGet<T>(string endpoint)
        {
            var apiReponse = new ApiResponse<T>();
            try
            {
                var response = await _httpClient.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                try
                {
                    var result = JsonSerializer.Deserialize<T>(content);
                    apiReponse.Result = result;
                }
                catch (Exception ex)
                {
                    apiReponse.ErrorMsg = ex.Message;
                    _logger.LogError(ex.Message);
                }
            }
            catch (HttpRequestException ex)
            {
                apiReponse.ErrorMsg = ex.Message;
                _logger.LogError(ex, ex.Message);
            }

            return apiReponse;
        }
    }
}
