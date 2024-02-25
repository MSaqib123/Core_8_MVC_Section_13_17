using Entities;
using Services;
using Services.DTO;
using Services.Enums;
using Services.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
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
            List<PersonResponse> allPersons = GetAllPersons();
            List<PersonResponse> matchingPersons = allPersons;

            if (string.IsNullOrEmpty(searchBy) || string.IsNullOrEmpty(SearchString))
                return matchingPersons;

            switch (searchBy)
            {
                case nameof(Person.PersonName):
                    matchingPersons = allPersons.Where(
                        x => (
                            !string.IsNullOrEmpty(x.PersonName) ? 
                            x.PersonName.Contains(SearchString, StringComparison.OrdinalIgnoreCase) :
                            true
                       )).ToList();
                    break;
                case nameof(Person.Email):
                    matchingPersons = allPersons.Where(
                        x => (
                            !string.IsNullOrEmpty(x.Email) ? 
                            x.PersonName.Contains(SearchString, StringComparison.OrdinalIgnoreCase) :
                            true
                       )).ToList();
                    break;

                case nameof(Person.DateOfBirth):
                    matchingPersons = allPersons.Where(
                        x => 
                            (x.DateOfBirth!=null) ?
                            x.DateOfBirth.Value.ToString("dd MMMM yyyy").Contains(SearchString, StringComparison.OrdinalIgnoreCase) :
                            true
                       ).ToList();
                    break;

                default:
                    matchingPersons = allPersons;
                    break;
            }

            return matchingPersons;

        }
        #endregion

        #region SortedPerson
        public List<PersonResponse> GetSortedPersons(List<PersonResponse> allPersons, string SortBy, SortOrderOptions sortOrder)
        {
            if (string.IsNullOrEmpty(SortBy))
                return allPersons;

            List<PersonResponse> sortedPersons = (SortBy, sortOrder)
            switch
            {
                (nameof(PersonResponse.PersonName), SortOrderOptions.ASC)
                => allPersons.OrderBy(temp => temp.PersonName, StringComparer.OrdinalIgnoreCase).ToList(),
                (nameof(PersonResponse.PersonName), SortOrderOptions.DESC)
                => allPersons.OrderByDescending(temp => temp.PersonName, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Address), SortOrderOptions.ASC)
                => allPersons.OrderBy(temp => temp.Address, StringComparer.OrdinalIgnoreCase).ToList(),
                (nameof(PersonResponse.Address), SortOrderOptions.DESC)
                => allPersons.OrderByDescending(temp => temp.Address, StringComparer.OrdinalIgnoreCase).ToList(),


                (nameof(PersonResponse.Gender), SortOrderOptions.ASC)
                => allPersons.OrderBy(temp => temp.Gender, StringComparer.OrdinalIgnoreCase).ToList(),
                (nameof(PersonResponse.Gender), SortOrderOptions.DESC)
                => allPersons.OrderByDescending(temp => temp.Gender, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Country), SortOrderOptions.ASC)
                => allPersons.OrderBy(temp => temp.Country, StringComparer.OrdinalIgnoreCase).ToList(),
                (nameof(PersonResponse.Country), SortOrderOptions.DESC)
                => allPersons.OrderByDescending(temp => temp.Country, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.DateOfBirth), SortOrderOptions.ASC)
                => allPersons.OrderBy(temp => temp.DateOfBirth).ToList(),
                (nameof(PersonResponse.DateOfBirth), SortOrderOptions.DESC)
                => allPersons.OrderByDescending(temp => temp.DateOfBirth).ToList(),

                (nameof(PersonResponse.Age), SortOrderOptions.ASC)
                => allPersons.OrderBy(temp => temp.Age).ToList(),
                (nameof(PersonResponse.Age), SortOrderOptions.DESC)
                => allPersons.OrderByDescending(temp => temp.Age).ToList(),
            };

            return sortedPersons;
        }
        #endregion

        #region UpdatePerson

        public PersonResponse UpdatePerson(PersonUpdateRequest update)
        {
            //check if "PersonUpdate" is null
            //validate all peroperties 
            //get the matching Person base on ID
            //check if matching Person object is not null
            //update all details from "PersonUpdateRequst" object to Person object
            //convert the person from Person to PersonResposne type
            //return  PersonResponse object with dublicate details

            if (update == null)
                throw new ArgumentNullException(nameof(Person));

            //validation
            ValidationHelper.ModelValidation(update);

            //get matching person
            Person? matchingPerson = _person.FirstOrDefault(temp => temp.PersonID == update.PersonId);
            if(matchingPerson == null)
            {
                throw new ArgumentException("Givin person id dosen't match");
            }

            //update all Detal
            matchingPerson.PersonName = update.PersonName;
            matchingPerson.Address = update.Address;
            matchingPerson.CountryID = update.CountryID;
            matchingPerson.DateOfBirth = update.DateOfBirth;
            matchingPerson.Email = update.Email;
            matchingPerson.Gender = update.Gender.ToString();
            matchingPerson.PersonID = update.PersonId;
            matchingPerson.ReceiveNewLetters = update.ReceiveNewLetters;

            return matchingPerson.ToPersonResponse();
        }
        #endregion

        #region Delete
        public bool DeletePerson(Guid? PersonID)
        {
            if (PersonID == null)
                throw new ArgumentNullException(nameof(PersonID));

            Person? person = _person.FirstOrDefault(temp => temp.PersonID == PersonID);

            if (person == null)
                return false;

            _person.RemoveAll(temp=>temp.PersonID == PersonID);
            return true;
        }
        #endregion

    }
}
