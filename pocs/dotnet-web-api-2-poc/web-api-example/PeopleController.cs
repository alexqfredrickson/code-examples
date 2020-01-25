using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DAL;
using DAL.Models;

namespace web_api_example
{
    // In this example, People in the DAL are uniquely identified by their e-mail addresses.

    public class PeopleController : ApiController
    {
        public PersonService Service = new PersonService();

        // GET api/<controller>
        public List<Person> Get()
        {
            return Service.People.Select(x => x).ToList<Person>();
        }

        /// <summary>
        /// GET api/<controller>/5
        /// </summary>
        /// <param name="email">A person's email address.</param>
        /// <returns></returns>
        public Person Get(string email)
        {
            return Service.People.Where(x => x.Email == email).Select(x => x).ToList<Person>().SingleOrDefault();
        }

        // POST api/<controller>
        public void Post([FromBody] Person newPerson)
        {
            Service.People.Add(newPerson);
            Service.SavePeopleToJson();
        }

        // PUT api/<controller>/5
        public void Put([FromBody] Person newPerson)
        {
            if (Service.People.Any(p => p.Email == newPerson.Email))
            {
                Person updatedPerson = Service.People.Where(p => p.Email == newPerson.Email).Select(p => p).First();
                int updatedPersonIndex = Service.People.IndexOf(updatedPerson);
                Service.People[updatedPersonIndex] = newPerson;
            }
            else
            {
                Service.People.Add(newPerson);
            }

            Service.SavePeopleToJson();
        }

        // DELETE api/<controller>/5
        public void Delete(string personEmail)
        {
            Service.People.RemoveAll(person => personEmail == person.Email);
            Service.SavePeopleToJson();
        }
    }
}