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
