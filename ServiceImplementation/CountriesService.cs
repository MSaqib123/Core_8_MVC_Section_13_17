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
        public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
        {
            //=== Null Validation ===
            if (countryAddRequest == null)
            {
                throw new ArgumentNullException(nameof(countryAddRequest));
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
    }
}