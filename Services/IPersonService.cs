using Services.DTO;
using Services.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Services
{
    public interface IPersonService
    {
        /// <summary>
        /// Add Person
        /// </summary>
        /// <param name="personAddRequest"></param>
        /// <returns></returns>
        PersonResponse AddPerson(PersonAddRequest? personAddRequest);

        /// <summary>
        /// getAll person
        /// </summary>
        /// <returns></returns>
        List<PersonResponse> GetAllPersons();

        /// <summary>
        /// get person byId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PersonResponse? GetPersonById(Guid? personId);

        /// <summary>
        /// return All records with matching searcbhBy , SearchString
        /// </summary>
        /// <param name="searchBy">Search Field to search</param>
        /// <param name="SearchString">Search string to search</param>
        /// <returns></returns>
        List<PersonResponse> GetFilteredPersons(string searchBy , string? SearchString);

        /// <summary>
        /// Return SortList of Person
        /// </summary>
        /// <param name="allPersons">List of persons</param>
        /// <param name="SortBy">On Whcih Column sort should apply</param>
        /// <param name="sortOrder">Asc , Desc</param>
        /// <returns></returns>
        List<PersonResponse> GetSortedPersons(List<PersonResponse> allPersons , string SortBy , SortOrderOptions sortOrder);


        PersonResponse UpdatePerson(PersonUpdateRequest update);

        /// <summary>
        /// Delee
        /// </summary>
        /// <param name="PersonID"></param>
        /// <returns></returns>
        bool DeletePerson(Guid? PersonID);

    }
}
