using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTO;
using Services.Enums;

namespace xUnitCRUD.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _IPersonService;
        public PersonController(IPersonService IPersonService)
        {
            _IPersonService = IPersonService;
        }

        public IActionResult PersonList(
            string? searchBy,string? searchString,
            string sortBy = nameof(PersonResponse.PersonName),SortOrderOptions sortOrder=SortOrderOptions.ASC)
        {
            List<PersonResponse> response = _IPersonService.GetAllPersons();

            //============ Searching ============
            ViewBag.SearchFields = new Dictionary<string, string>()
            {
                {nameof(PersonResponse.PersonName),"PersonName" },
                {nameof(PersonResponse.Email),"Email" },
                {nameof(PersonResponse.Address),"Address" },
                {nameof(PersonResponse.Gender),"Gender" },
                {nameof(PersonResponse.DateOfBirth),"DateOfBirth" },
                {nameof(PersonResponse.CountryID),"CountryID" },
            };
            if (!string.IsNullOrEmpty(searchBy) && !string.IsNullOrEmpty(searchString))
            {
                response = _IPersonService.GetFilteredPersons(searchBy,searchString);
            }
            ViewBag.CurrentSearchBy = searchBy;
            ViewBag.CurrentSearchString = searchString;


            //============ Sort ============
            response = _IPersonService.GetSortedPersons(response,sortBy, sortOrder);

            ViewBag.SortBy = sortBy;
            ViewBag.sortOrder = sortOrder.ToString();

            return View(response);
        }
    }
}
