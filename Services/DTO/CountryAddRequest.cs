using Entities;
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
    public class CountryAddRequest
    {
        //we don not add Id in  Request
        public string? CountryName { get; set; }

        //___ Convert CountryRequest to CountryModel ___
        public Country ToCountry()
        {
            return new Country()
            {
                CountryName = CountryName
            };
        }
    }
}
