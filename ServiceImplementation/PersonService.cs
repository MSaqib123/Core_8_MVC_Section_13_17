using Entities;
using Services;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation
{
    public class PersonService : IPersonService
    {
        private readonly List<Person> _person;
        private readonly ICountiesService _countiesService;
        public PersonService()
        {
            _person = new List<Person>();
            _countiesService = new CountriesService();
        }

        private PersonResponse ConvertPersonToPersonResponse(Person person)
        {
            //convert the person object into PersonResponceType
            PersonResponse responsePerson = person.ToPersonResponse();
            //null coalition operators
            responsePerson.Country = _countiesService.GetCountryByCountryId(person.CountryID)?.CountryName;
            return responsePerson;
        }

        #region Add_person
        public PersonResponse AddPerson(PersonAddRequest? personAddRequest)
        {
            //null
            if (personAddRequest == null)
            {
                throw new ArgumentNullException(nameof(personAddRequest));
            }
            //name null
            if (string.IsNullOrEmpty(personAddRequest.PersonName))
            {
                throw new ArgumentException("PersonName is null");
            }

            //convert to personAddRequst
            Person person = personAddRequest.ToPerson();

            //new id
            person.PersonID = Guid.NewGuid();

            //add person
            _person.Add(person);

            //convert to personRespsne
            return ConvertPersonToPersonResponse(person);

        }
        #endregion

        public List<PersonResponse> GetAllPersons()
        {
            throw new NotImplementedException();
        }

        public PersonResponse GetPersonById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
