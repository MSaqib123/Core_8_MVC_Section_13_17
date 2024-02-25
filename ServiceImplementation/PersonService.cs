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
        public PersonService(bool initialize = true)
        {
            _person = new List<Person>();
            _countiesService = new CountriesService();
            if (initialize)
            {
                //private filed
                _person.AddRange(new List<Person>()
                {
                    new Person()
                    {
                        PersonID = Guid.Parse("2a8cbf0d-dad0-4d13-925f-7c1e152df715"),
                        PersonName = "Pakistan",
                        Address = "dil dil pkaistna",
                        CountryID = Guid.Parse("5f9a6b33-04e8-47a7-bc1d-e5cc29f42647"),
                        DateOfBirth = DateTime.Now,
                        Email = "m435777535@gmail.com",
                        Gender = GenderOptions.Male.ToString(),
                        ReceiveNewLetters = true
                    },
                    new Person()
                    {
                        PersonID = Guid.Parse("5f9a6b33-04e8-47a7-bc1d-e5cc29f42647"),
                        PersonName = "John Doe",
                        Address = "123 Main St",
                        CountryID = Guid.Parse("e8f5f7d6-6a8d-44e1-9b32-c0521c4528f2"),
                        DateOfBirth = new DateTime(1990, 5, 15),
                        Email = "john.doe@example.com",
                        Gender = GenderOptions.Male.ToString(),
                        ReceiveNewLetters = false
                    },
                    new Person()
                    {
                        PersonID = Guid.Parse("e8f5f7d6-6a8d-44e1-9b32-c0521c4528f2"),
                        PersonName = "Jane Smith",
                        Address = "456 Oak St",
                        CountryID = Guid.Parse("9a23f296-6955-464c-87e3-8e2a2d1a38ef"),
                        DateOfBirth = new DateTime(1985, 10, 8),
                        Email = "jane.smith@example.com",
                        Gender = GenderOptions.Female.ToString(),
                        ReceiveNewLetters = true
                    },
                    new Person()
                    {
                        PersonID = Guid.Parse("9a23f296-6955-464c-87e3-8e2a2d1a38ef"),
                        PersonName = "Michael Johnson",
                        Address = "789 Elm St",
                        CountryID = Guid.Parse("d8eb3709-3e11-4dd7-a02c-6e54dd6e6575"),
                        DateOfBirth = new DateTime(1978, 3, 20),
                        Email = "michael.johnson@example.com",
                        Gender = GenderOptions.Male.ToString(),
                        ReceiveNewLetters = true
                    },
                    new Person()
                    {
                        PersonID = Guid.Parse("d8eb3709-3e11-4dd7-a02c-6e54dd6e6575"),
                        PersonName = "Emily Davis",
                        Address = "321 Pine St",
                        CountryID = Guid.Parse("c7a8b3d2-f1c2-4971-b7bb-dcbb24a9e731"),
                        DateOfBirth = new DateTime(1995, 12, 3),
                        Email = "emily.davis@example.com",
                        Gender = GenderOptions.Female.ToString(),
                        ReceiveNewLetters = false
                    },
                    new Person()
                    {
                        PersonID = Guid.Parse("c7a8b3d2-f1c2-4971-b7bb-dcbb24a9e731"),
                        PersonName = "Chris Wilson",
                        Address = "987 Maple St",
                        CountryID = Guid.Parse("6d206107-4e43-4468-b8f1-d3455ed6f5e0"),
                        DateOfBirth = new DateTime(1982, 8, 12),
                        Email = "chris.wilson@example.com",
                        Gender = GenderOptions.Male.ToString(),
                        ReceiveNewLetters = true
                    },
                    new Person()
                    {
                        PersonID = Guid.Parse("6d206107-4e43-4468-b8f1-d3455ed6f5e0"),
                        PersonName = "Emma Anderson",
                        Address = "654 Cedar St",
                        CountryID = Guid.Parse("a1e601e5-119a-4777-ae15-94e5b8eaf118"),
                        DateOfBirth = new DateTime(1993, 6, 25),
                        Email = "emma.anderson@example.com",
                        Gender = GenderOptions.Female.ToString(),
                        ReceiveNewLetters = false
                    },
                    new Person()
                    {
                        PersonID = Guid.Parse("a1e601e5-119a-4777-ae15-94e5b8eaf118"),
                        PersonName = "Matthew Taylor",
                        Address = "852 Birch St",
                        CountryID = Guid.Parse("bd8f3a91-c1db-4c62-aa8f-6fd9b5e9a09d"),
                        DateOfBirth = new DateTime(1975, 9, 18),
                        Email = "matthew.taylor@example.com",
                        Gender = GenderOptions.Male.ToString(),
                        ReceiveNewLetters = true
                    },
                    new Person()
                    {
                        PersonID = Guid.Parse("bd8f3a91-c1db-4c62-aa8f-6fd9b5e9a09d"),
                        PersonName = "Olivia Martinez",
                        Address = "369 Walnut St",
                        CountryID = Guid.Parse("6aebcd10-2c68-4211-8e34-9d69fda4d63d"),
                        DateOfBirth = new DateTime(1988, 11, 30),
                        Email = "olivia.martinez@example.com",
                        Gender = GenderOptions.Female.ToString(),
                        ReceiveNewLetters = true
                    },
                    new Person()
                    {
                        PersonID = Guid.Parse("6aebcd10-2c68-4211-8e34-9d69fda4d63d"),
                        PersonName = "David Brown",
                        Address = "147 Pine St",
                        CountryID = Guid.Parse("2a8cbf0d-dad0-4d13-925f-7c1e152df715"),
                        DateOfBirth = new DateTime(1980, 4, 10),
                        Email = "david.brown@example.com",
                        Gender = GenderOptions.Male.ToString(),
                        ReceiveNewLetters = false
                    }
                });

            }
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
            Person? person = _person.FirstOrDefault(x => x.PersonID == personId);

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
                            (x.DateOfBirth != null) ?
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
            if (matchingPerson == null)
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

            _person.RemoveAll(temp => temp.PersonID == PersonID);
            return true;
        }
        #endregion

    }
}
