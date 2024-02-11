using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    /// <summary>
    /// DTO class that is used to return data
    /// 1. Requst will send data to Domain layer
    /// 2. Response will get DAta from Domain Layer
    /// 3. But Domain will not Be Exposed or visable that whats happing in Behinde seen
    /// </summary>
    public class CountryResponse
    {
        public Guid CountryId { get; set; }
        public string? CountryName { get; set; }

        //_____ Compairing Response List Values with Added Object _______
        /// <summary>
        /// its Compair the Current object to another object of country type and return true , if both values are same; otherwiseresutn false
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            
            if (obj.GetType() != typeof(CountryResponse))
            {
                return false;
            }
            CountryResponse country_to_compare = (CountryResponse)obj;
            var condition = CountryId == country_to_compare.CountryId && CountryName == country_to_compare.CountryName;
            return condition;
        }


    }
    public static class CountryExtension
    {
        public static CountryResponse ToContryResponse(this Country country)
        {
            return new CountryResponse()
            {
                CountryId = country.CountryId,
                CountryName = country.CountryName
            };
        }
    }
}
