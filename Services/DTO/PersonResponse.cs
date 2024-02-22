using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    /// <summary>
    /// PersonResposne
    /// </summary>
    public class PersonResponse
    {
        public Guid PersonID { get; set; }
        public string? PersonName { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public Guid? CountryID { get; set; }
        public string? Address { get; set; }
        public bool? ReceiveNewLetters { get; set; }
        public double? Age{ get; set; }
        public string? Country { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj.GetType() != typeof(PersonResponse))
            {
                return false;
            }
            PersonResponse personR = (PersonResponse)obj;
            var condition = PersonID == personR.PersonID &&
                    PersonID == personR.PersonID &&
                    PersonName == personR.PersonName &&
                    Email == personR.Email &&
                    DateOfBirth == personR.DateOfBirth &&
                    Gender == personR.Gender.ToString() &&
                    CountryID == personR.CountryID &&
                    Address == personR.Address &&
                    ReceiveNewLetters == personR.ReceiveNewLetters;
            return condition;
        }

        /// <summary>
        /// removing Class warning because if we override Equal then we have to override Equals
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return $"PersonId: {PersonID}, PersonName: {PersonName}, Email: {Email}, DateOfBirth: {DateOfBirth}, Gender: {Gender}, CountryID: {CountryID}, Address: {Address}, ReceiveNewLetters: {ReceiveNewLetters}, Age: {Age}, Country: {Country}";
        }


    }
    public static class PersonExtension
    {
        public static PersonResponse ToPersonResponse(this Person person)
        {
            return new PersonResponse()
            {
                PersonID = person.PersonID,
                PersonName = person.PersonName,
                Email = person.Email,
                DateOfBirth = person.DateOfBirth,
                Gender = person?.Gender?.ToString(),
                CountryID = person.CountryID,
                Address = person.Address,
                ReceiveNewLetters = person.ReceiveNewLetters,
                Age = person.DateOfBirth != null ? Math.Round((DateTime.Now - person.DateOfBirth.Value).TotalDays /365.25) : null
            };
        }
    }
}
