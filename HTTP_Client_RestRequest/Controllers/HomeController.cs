using HTTP_Client_RestRequest.Models;
using HTTP_Client_RestRequest.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace HTTP_Client_RestRequest.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyServices _service;
        private readonly IOptions<FinnhubConfiguration> _configuration;

        public HomeController( MyServices service, IOptions<FinnhubConfiguration> configuration)
        {
            _service = service;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            string symbol = _configuration.Value.DfaultStockSymbol?? "MSFT";
            Dictionary<string,object> response = await _service.getStrockPriceQuote(symbol);

            StockUpdate stockP = new StockUpdate();
            stockP.StockSymbol = symbol;
            var c = response["c"];
            var h = response["h"];
            var l = response["l"];
            var o = response["o"];

            stockP.CurrentPrice = c.ToString();
            stockP.HighestPrice = h.ToString();
            stockP.LowesPrice = l.ToString();
            stockP.OpenPrice = o.ToString();


            return View(stockP);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}