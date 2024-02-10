using System.Net.NetworkInformation;
using System.Text.Json;

namespace HTTP_Client_RestRequest.Service
{
    public class MyServices : IMyServices
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public MyServices(IHttpClientFactory httpClientFactory,IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<Dictionary<string, object>> getStrockPriceQuote(string stockSymbol)
        {
            using (HttpClient httpClient = _httpClientFactory.CreateClient())
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
                {
                    RequestUri = new Uri($"https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token={_configuration["FinnhubToken"]}"),
                    Method = HttpMethod.Get,
                };
                HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                Stream stream = httpResponseMessage.Content.ReadAsStream();
                StreamReader streamRead = new StreamReader(stream);

                string response = streamRead.ReadToEnd();

                Dictionary<string, object>? responseDectonary = JsonSerializer.Deserialize<Dictionary<string, object>>(response);

                if (responseDectonary == null)
                    throw new InvalidOperationException("NO response");
                if (responseDectonary.ContainsKey("error"))
                    throw new InvalidOperationException(Convert.ToString(responseDectonary["error"]));

                return responseDectonary;
            }
        }
    }
}
