using Services.DTO;

namespace Services
{
    /// <summary>
    /// Represent  BusniceLogic  DI for  Country
    /// </summary>
    public interface ICountiesService
    {
        CountryResponse AddCountry(CountryAddRequest? countryAddRequest);
    }
}