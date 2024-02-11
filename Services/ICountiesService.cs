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
        /// GetAllCountries for Getting All countreis
        /// </summary>
        /// <returns></returns>
        List<CountryResponse> GetAllCountries();

        /// <summary>
        /// GetCountry by CountryId
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        CountryResponse? GetCountryByCountryId(Guid? countryId);
    }
}