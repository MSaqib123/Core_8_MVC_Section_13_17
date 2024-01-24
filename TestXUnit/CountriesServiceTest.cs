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
        public void AddCountry_NullCountryDetail()
        {
            //Arrange
            CountryAddRequest? Req1 = new CountryAddRequest() { CountryName = "Japan" };

            //act
            CountryResponse resposne = _countiesService.AddCountry(Req1);

            //Assert
            Assert.True(resposne.CountryId != Guid.Empty);
        }

    }

}
