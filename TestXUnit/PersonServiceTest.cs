using Services;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestXUnit
{
    public class PersonServiceTest
    {
        //private fields
        private readonly IPersonService _personService;
        public PersonServiceTest(IPersonService personService)
        {
            _personService = personService;
        }

        //===============================
        //--------- Person --------------
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
        //--------- Person --------------
        //===============================
        [Fact]
        public void AddPerson_ProperNameIsPerson()
        {
            //Arrange
            PersonAddRequest? personAddRequest = new PersonAddRequest() { PersonName = null};

            //Act
            _personService.AddPerson(personAddRequest);
        }
        


        ///Pakistan zindiabad
        ///Pakistan zindiabad
        ///Pakistan zindiabad
        ///Pakistan zindiabad
        ///Pakistan zindiabad
        ///Pakistan zindiabad

    }
}
