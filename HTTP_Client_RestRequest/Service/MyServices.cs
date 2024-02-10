﻿using System.Net.NetworkInformation;
using System.Text.Json;

namespace HTTP_Client_RestRequest.Service
{
    public class MyServices : IMyServices
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public MyServices(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Dictionary<string, object>> getStrockPriceQuote()
        {
            using (HttpClient httpClient = _httpClientFactory.CreateClient())
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://finnhub.io/api/v1/quote?symbol=AAPL&token=cn378f9r01qtdiertrtgcn378f9r01qtdiertru0"),
                    Method = HttpMethod.Get,
                };
                HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                Stream stream = httpResponseMessage.Content.ReadAsStream();
                StreamReader streamRead = new StreamReader(stream);

                string response = streamRead.ReadToEnd();

                Dictionary<string, object>? responseDectonary = JsonSerializer.Deserialize<Dictionary<string, object>>(response);
                return responseDectonary;
            }
        }
    }
}
