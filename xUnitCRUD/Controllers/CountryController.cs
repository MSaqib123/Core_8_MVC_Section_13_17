using Microsoft.AspNetCore.Mvc;

namespace xUnitCRUD.Controllers
{
    public class CountryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
