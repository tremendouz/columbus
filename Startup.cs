using Microsoft.Net.Http.Headers;

namespace ColumbusTest
{
    public static class Startup
    {
        public static HttpClient SetupHttpClient(IConfigurationRoot config, HttpClient client)
        {
            client.BaseAddress = new Uri(config["BaseAddress"]);
            var apiKey = config["ApiKey"];
           
            client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            client.DefaultRequestHeaders.Add("ApiKey", apiKey);
            return client;
        }
    }
}
