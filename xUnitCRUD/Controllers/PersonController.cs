using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services;
using Services.DTO;
using Services.Enums;

namespace xUnitCRUD.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _IPersonService;
        private readonly ICountiesService _countiesService;
        public PersonController(IPersonService IPersonService,ICountiesService countiesService)
        {
            _IPersonService = IPersonService;
            _countiesService = countiesService;
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


        public IActionResult PersonCreate()
        {
            var model = new PersonAddRequest();
            List<CountryResponse> list = _countiesService.GetAllCountries();
            //ViewBag.Countries = list;
            ViewBag.Countries = list.Select(x => new SelectListItem()
            {
                Text = x.CountryName,
                Value = x.CountryId.ToString(),

            });
            return View(model);
        }
        [HttpPost]
        public IActionResult PersonCreate(PersonAddRequest model)
        {
            if (!ModelState.IsValid)
            {
                List<CountryResponse> list = _countiesService.GetAllCountries();
                ViewBag.Countries = list;
                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return View(model);
            }
            else
            {
                var addingPerson = _IPersonService.AddPerson(model);
                return RedirectToAction(nameof(PersonCreate));
            }
        }
    }
}
