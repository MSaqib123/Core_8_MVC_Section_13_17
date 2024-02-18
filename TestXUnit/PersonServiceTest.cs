using ServiceImplementation;
using Services;
using Services.DTO;
using Services.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestXUnit
{
    public class PersonServiceTest
    {
        //private fields
        private readonly IPersonService _personService;
        public PersonServiceTest()
        {
            _personService = new PersonService();
        }

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


    }
}
