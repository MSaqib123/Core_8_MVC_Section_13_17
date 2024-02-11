using Entities;
using Services;
using Services.DTO;

namespace ServiceImplementation
{
    public class CountriesService : ICountiesService
    {
        private readonly List<Country> _countries;
        public CountriesService()
        {
            _countries = new List<Country>();
        }

        #region AddCountry
        public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
        {
            //=== 1. Null Validation ===
            if (countryAddRequest == null)
            {
                throw new ArgumentNullException(nameof(countryAddRequest));
            }
            //=== 2. Null Name Validation ===
            if (countryAddRequest.CountryName == null)
            {
                throw new ArgumentNullException(nameof(countryAddRequest.CountryName));
            }
            //=== 2. dublicate Validation ===
            if (_countries.Where(temp=>temp.CountryName == countryAddRequest.CountryName).Count() > 0)
            {
                throw new ArgumentNullException("Given CountryName alredy Exist in Table");
            }

            //convert CountryRequest to Country Object
            Country country = countryAddRequest.ToCountry();

            //generate countryId
            country.CountryId = Guid.NewGuid();

            //Add county object int _country
            _countries.Add(country);

            //convert country to countryResponse object
            return country.ToContryResponse();


        }

        #endregion

        #region GetCountryList
        public List<CountryResponse> GetAllCountries()
        {
            return _countries.Select(country => country.ToContryResponse()).ToList();
        }
        #endregion
    }
}