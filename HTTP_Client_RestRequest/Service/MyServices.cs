using System.Net.NetworkInformation;

namespace HTTP_Client_RestRequest.Service
{
    public class MyServices
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public MyServices(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task method()
        {
            using (HttpClient httpClient = _httpClientFactory.CreateClient())
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
                {
                    RequestUri = new Uri("url"),
                    Method = HttpMethod.Get,
                };
                HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            }
        }
    }
}
