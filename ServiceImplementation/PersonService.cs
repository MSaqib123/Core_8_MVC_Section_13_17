using Entities;
using Services;
using Services.DTO;
using Services.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
            //if (string.IsNullOrEmpty(personAddRequest.PersonName))
            //{
            //    throw new ArgumentException("PersonName is null");
            //}

            //___ Model Validation ____
            //ValidationContext validationContext = new ValidationContext(personAddRequest);
            //List<ValidationResult> validationResults = new List<ValidationResult>();
            //bool isValid = Validator.TryValidateObject(personAddRequest,validationContext,validationResults,true);
            //if (!isValid)
            //{
            //    throw new ArgumentException(validationResults.FirstOrDefault()?.ErrorMessage);
            //}

            //____ external Class _____
            ValidationHelper.ModelValidation(personAddRequest);

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

        #region GetAllPerson
        public List<PersonResponse> GetAllPersons()
        {
            //throw new NotImplementedException();
            List<PersonResponse> listPersonResponse = _person.Select(x => x.ToPersonResponse()).ToList();
            return listPersonResponse;
        }
        #endregion

        #region GetPersonById
        public PersonResponse? GetPersonById(Guid? personId)
        {
            //throw new NotImplementedException();
            if (personId == null)
                return null;
            Person? person = _person.FirstOrDefault(x=>x.PersonID == personId);

            if (person == null)
                return null;

            //convert to personResponse   (hidding orignal Model)
            return person.ToPersonResponse();
        }
        #endregion

        #region GetFilteredPersons
        /// <summary>
        /// Return all person that match with the given search field and search
        /// </summary>
        /// <param name="searchBy">Search Field to search</param>
        /// <param name="SearchString">Search string to search</param>
        /// <returns>Return all person that match with the given search field and search</returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<PersonResponse> GetFilteredPersons(string searchBy, string? SearchString)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
