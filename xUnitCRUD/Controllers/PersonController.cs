using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTO;

namespace xUnitCRUD.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _IPersonService;
        public PersonController(IPersonService IPersonService)
        {
            _IPersonService = IPersonService;
        }

        public IActionResult PersonList(string? searchBy,string? searchString)
        {
            ViewBag.SearchFields = new Dictionary<string, string>()
            {
                {nameof(PersonResponse.PersonName),"PersonName" },
                {nameof(PersonResponse.Email),"Email" },
                {nameof(PersonResponse.Address),"Address" },
                {nameof(PersonResponse.Gender),"Gender" },
                {nameof(PersonResponse.DateOfBirth),"DateOfBirth" },
                {nameof(PersonResponse.CountryID),"CountryID" },
            };
            List<PersonResponse> response = _IPersonService.GetAllPersons();
            //___ Filter Records ___
            if (!string.IsNullOrEmpty(searchBy) && !string.IsNullOrEmpty(searchString))
            {
                response = _IPersonService.GetFilteredPersons(searchBy,searchString);
            }
            return View(response);
        }
    }
}
