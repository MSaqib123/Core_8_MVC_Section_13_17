using Entities;
using Services.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    /// <summary>
    /// DTO class to add new Country
    /// </summary>
    public class PersonAddRequest
    {
        //we don not add Id in  Request
        public string? PersonName { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public GenderOptions? Gender { get; set; }
        public Guid? CountryID { get; set; }
        public string? Address { get; set; }
        public bool? ReceiveNewLetters { get; set; }

        //___ Convert CountryRequest to CountryModel ___
        public Person ToPerson()
        {
            return new Person()
            {
                PersonName = PersonName,
                Email = Email,
                DateOfBirth = DateOfBirth,
                Gender = Gender.ToString(),
                CountryID = CountryID,
                Address = Address,
                ReceiveNewLetters = ReceiveNewLetters
            };
        }
    }
}
