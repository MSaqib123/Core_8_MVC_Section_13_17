using HTTP_Client_RestRequest.Models;
using HTTP_Client_RestRequest.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HTTP_Client_RestRequest.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyServices _service;

        public HomeController( MyServices service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            await _service.method();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}