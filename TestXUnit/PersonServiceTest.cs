using ServiceImplementation;
using Services;
using Services.DTO;
using Services.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace TestXUnit
{
    public class PersonServiceTest
    {
        //private fields
        private readonly IPersonService _personService;
        private readonly ICountiesService _countryService;
        public PersonServiceTest()
        {
            _personService = new PersonService();
            _countryService = new CountriesService();
        }

        //________ Add Person ___________
        #region Add_person

        //===============================
        //--------- Person null object execption --------------
        //===============================
        [Fact]
        public void AddPerson_NullPerson()
        {
            //Arrange
            PersonAddRequest? personAddRequest = null;

            //Act
            Assert.Throws<ArgumentNullException>(() =>
            {
                _personService.AddPerson(personAddRequest);
            });
        }

        //===============================
        //--------- Person argument Exeption --------------
        //===============================
        [Fact]
        public void AddPerson_ProperNameIsPerson()
        {
            //Arrange
            PersonAddRequest? personAddRequest = new PersonAddRequest() { PersonName = null };

            //Act
            Assert.Throws<ArgumentException>(() =>
            {
                _personService.AddPerson(personAddRequest);
            });
        }

        //===============================
        //--------- Person complete details insert --------------
        //===============================
        [Fact]
        public void AddPerson_ProperPersonDetails()
        {
            //Arrange
            PersonAddRequest? personAddRequest = new PersonAddRequest()
            {
                PersonName = "",
                Email = "",
                DateOfBirth = DateTime.Now,
                Gender = GenderOptions.Male,
                CountryID = Guid.NewGuid(),
                Address = "Pakista",
                ReceiveNewLetters = true,

            };

            //Act
            PersonResponse? add_person_resposne = _personService.AddPerson(personAddRequest);
            List<PersonResponse> person_List = _personService.GetAllPersons();

            //Assert 
            Assert.True(add_person_resposne.PersonID != Guid.Empty);
            Assert.Contains(add_person_resposne, person_List);
        }
        #endregion

        //________ Get Person by id ___________
        #region GetPersonById
        //nullId
        [Fact]
        public void GetPersonByPersonId_NullPersonID()
        {
            //arrange
            Guid? personId = null;

            //act
            PersonResponse? person_response_from_get = _personService.GetPersonById(personId);

            //assert
            Assert.Null(person_response_from_get);
        }

        [Fact]
        public void GetPersonByPersonId_WithPersonID()
        {
            //Arrange 
            CountryAddRequest country_requst = new CountryAddRequest()
            {
                CountryName = "Canda"
            };
            CountryResponse country_Response = _countryService.AddCountry(country_requst);

            //Act
            PersonAddRequest person_request = new PersonAddRequest()
            {
                PersonName = "Person name ",
                Email = "email@sample.com",
                DateOfBirth = DateTime.Now,
                Gender = GenderOptions.Male,
                CountryID = country_Response.CountryId,
                Address = "Pakistan",
                ReceiveNewLetters = false,
            };
            PersonResponse person_response = _personService.AddPerson(person_request);
            PersonResponse? person_resposne_from_get = _personService.GetPersonById(person_response.PersonID);

            //Assert
            Assert.Equal(person_response,person_resposne_from_get);
        }

        #endregion

    }
}
