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
            var response = await _service.getStrockPriceQuote(_configuration.Value.DfaultStockSymbol);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}