using Services;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation
{
    public class PersonService : IPersonService
    {
        public PersonResponse AddPerson(PersonAddRequest? personAddRequest)
        {
            throw new NotImplementedException();
        }

        public List<PersonResponse> GetAllPersons()
        {
            throw new NotImplementedException();
        }

        public PersonResponse GetPersonById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
