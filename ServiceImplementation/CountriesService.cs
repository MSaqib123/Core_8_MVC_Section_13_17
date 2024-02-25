using Entities;
using Services;
using Services.DTO;

namespace ServiceImplementation
{
    public class CountriesService : ICountiesService
    {
        private readonly List<Country> _countries;
        public CountriesService(bool initialize = true)
        {
            _countries = new List<Country>();
            if (initialize)
            {
                //private filed
                _countries.AddRange(new List<Country>()
                {
                    new Country()
                    {
                        CountryId = Guid.Parse("2a8cbf0d-dad0-4d13-925f-7c1e152df715"),
                        CountryName = "Pakistan"
                    },
                    new Country()
                    {
                        CountryId = Guid.Parse("5f9a6b33-04e8-47a7-bc1d-e5cc29f42647"),
                        CountryName = "India"
                    },
                    new Country()
                    {
                        CountryId = Guid.Parse("e8f5f7d6-6a8d-44e1-9b32-c0521c4528f2"),
                        CountryName = "Srilanka"
                    },
                    new Country()
                    {
                        CountryId = Guid.Parse("9a23f296-6955-464c-87e3-8e2a2d1a38ef"),
                        CountryName = "Australia"
                    },
                    new Country()
                    {
                        CountryId = Guid.Parse("d8eb3709-3e11-4dd7-a02c-6e54dd6e6575"),
                        CountryName = "England"
                    },
                    new Country()
                    {
                        CountryId = Guid.Parse("c7a8b3d2-f1c2-4971-b7bb-dcbb24a9e731"),
                        CountryName = "Bangladash"
                    },
                    new Country()
                    {
                        CountryId = Guid.Parse("6d206107-4e43-4468-b8f1-d3455ed6f5e0"),
                        CountryName = "Afghanistan"
                    },
                    new Country()
                    {
                        CountryId = Guid.Parse("a1e601e5-119a-4777-ae15-94e5b8eaf118"),
                        CountryName = "Newzeland"
                    },
                });
            }
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

        #region GetCountryById
        public CountryResponse? GetCountryByCountryId(Guid? countryId)
        {
            if (countryId == null)
                return null;

            Country? Country_resposne_from_list = _countries.FirstOrDefault(country => country.CountryId == countryId);
            if (Country_resposne_from_list == null)
                return null;

            return Country_resposne_from_list.ToContryResponse(); //null;
        }
        #endregion
    }
}