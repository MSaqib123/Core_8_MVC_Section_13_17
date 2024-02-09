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
                    RequestUri = new Uri("https://finnhub.io/api/v1/quote?symbol=AAPL&token=cn378f9r01qtdiertrtgcn378f9r01qtdiertru0"),
                    Method = HttpMethod.Get,
                };
                HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            }
        }
    }
}
