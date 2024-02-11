using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IPersonService
    {
        /// <summary>
        /// Add Person
        /// </summary>
        /// <param name="personAddRequest"></param>
        /// <returns></returns>
        PersonResponse AddPerson(PersonAddRequest personAddRequest);
        /// <summary>
        /// GetPerson
        /// </summary>
        /// <param name="PersonId"></param>
        /// <returns></returns>
        List<PersonResponse> GetAllPersons(int? PersonId);
    }
}
