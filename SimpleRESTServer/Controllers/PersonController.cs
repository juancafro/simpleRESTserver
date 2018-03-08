using SimpleRESTServer.DAL;
using SimpleRESTServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleRESTServer.Controllers
{
    public class PersonController : ApiController
    {
        // GET: api/Person
        public IEnumerable<Person> Get()
        {
            PersonRepository repo = new PersonRepository();
            return repo.ListAll();
        }

        // GET: api/Person/5
        public Person Get(int id)
        {

            Person a = new Person();
            
            PersonRepository repo = new PersonRepository();
            a=repo.get(id);

            Console.WriteLine("success");
            return a;
        }

        // POST: api/Person
        public void Post([FromBody]Person value)
        {
            PersonRepository repo = new PersonRepository();
            repo.Add(value);
        }

        // PUT: api/Person/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/Person/5
        public void Delete(int id)
        {

        }
    }
}
