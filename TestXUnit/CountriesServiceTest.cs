using ServiceImplementation;
using Services;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestXUnit
{
    public class CountriesServiceTest
    {
        private readonly ICountiesService _countiesService;
        public CountriesServiceTest()
        {
            _countiesService = new CountriesService();
        }
        #region Add_Country

        //=============================================================
        //============== 1. CountryAddResult Is Null ==================
        //============================================================= 
        [Fact]
        public void AddCountry_NullCountry()
        {
            //Arrange
            CountryAddRequest? Req = null;
            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                _countiesService.AddCountry(Req);
            });
        }
        //=============================================================
        //============== 2. CountryName Is Null ==================
        //============================================================= 
        [Fact]
        public void AddCountry_NullCountryName()
        {
            //Arrange
            CountryAddRequest? Req = new CountryAddRequest() { CountryName = null };

            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                _countiesService.AddCountry(Req);
            });
        }

        //=============================================================
        //============== 3. CountryName Is dublicate ==================
        //============================================================= 
        [Fact]
        public void AddCountry_NullCountryDublicate()
        {
            //Arrange
            CountryAddRequest? Req1 = new CountryAddRequest() { CountryName = "Pakistan" };
            CountryAddRequest? Req2 = new CountryAddRequest() { CountryName = "Pakistan" };

            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                _countiesService.AddCountry(Req1);
                _countiesService.AddCountry(Req2);
            });
        }

        //=============================================================
        //============== 4. supply proper country name ==================
        //============================================================= 
        [Fact]
        public void AddCountry_ProperCountryDetail()
        {
            //Arrange
            CountryAddRequest? Req1 = new CountryAddRequest() { CountryName = "Japan" };

            //act
            CountryResponse resposne = _countiesService.AddCountry(Req1);
            List<CountryResponse> countries_from_GetAllCountries = _countiesService.GetAllCountries();

            //Assert
            Assert.True(resposne.CountryId != Guid.Empty);
            //here its automatically dedect that  equal values 
            Assert.Contains(resposne,countries_from_GetAllCountries);
        }

        #endregion


        #region GetCountry_List
        [Fact]
        public void GetAllCountries_EmptyList()
        {
            //Act
            List<CountryResponse> Actual_Country_Response_List = _countiesService.GetAllCountries();

            //Assert
            Assert.Empty(Actual_Country_Response_List);
        }

        [Fact]
        public void GetAllCountries_AddFewCountries()
        {
            //Arrange 
            List<CountryAddRequest> country_request_list = new List<CountryAddRequest>()
            {
                new CountryAddRequest(){CountryName="USA"},
                new CountryAddRequest(){CountryName = "India"}
            };

            //Act
            List<CountryResponse> country_List_fromAdd_country = new List<CountryResponse>();
            foreach (CountryAddRequest item in country_request_list)
            {
                country_List_fromAdd_country.Add(_countiesService.AddCountry(item));
            }

            //Assert
            List<CountryResponse>  actualCountryResponseList= _countiesService.GetAllCountries();
            foreach (var expectCountry in country_List_fromAdd_country)
            {

                Assert.Contains(expectCountry,actualCountryResponseList);
            }
        }

        #endregion


        #region GetCountryById
        
        [Fact]
        public void GetCountryByCountryId_NullCountryId()
        {
            //Arrang
            Guid? countryId = null;

            //act
            CountryResponse? Country_respopnse_from_get_method = _countiesService.GetCountryByCountryId(countryId);

            //Assert
            Assert.Null(Country_respopnse_from_get_method);
        }

        [Fact]
        public void GetCountryByCountryId_ValidCountryId()
        {
            //Arrang
            Guid? countryId = null;

            //act
            CountryResponse? Country_respopnse_from_get_method = _countiesService.GetCountryByCountryId(countryId);

            //Assert
            Assert.Null(Country_respopnse_from_get_method);
        }
        #endregion
    }

}
