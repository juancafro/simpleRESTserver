using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRESTServer.Models
{
    interface IPersonRepository
    {
        IEnumerable<Person> ListAll();
        Person get(int id);
        int Add(Person p);
        void Remove(int id);
        bool Update(Person p);
    }
}
