using Services;
using Services.DTO;

namespace ServiceImplementation
{
    public class CountriesService : ICountiesService
    {
        public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
        {
            return new CountryResponse() { CountryName = countryAddRequest.CountryName };
        }
    }
}