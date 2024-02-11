using Services.DTO;

namespace Services
{
    public interface ICountiesService
    {
        /// <summary>
        /// Represent  BusniceLogic  DI for  Country
        /// </summary>
        /// <param name="countryAddRequest"></param>
        /// <returns></returns>
        CountryResponse AddCountry(CountryAddRequest? countryAddRequest);

        /// <summary>
        /// GetAllCountries 
        /// </summary>
        /// <returns></returns>
        List<CountryResponse> GetAllCountries();
    }
}