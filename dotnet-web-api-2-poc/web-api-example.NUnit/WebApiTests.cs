using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using DAL.Models;

namespace web_api_example.NUnit
{
    [TestFixture]
    public class WebApiTests
    {
        private PeopleController Controller { get; set; }
        private static string BackupJsonPath = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\web-api-example.NUnit\people.json"; // path relative to NUnit console runner

        [SetUp]
        public void Init()
        {
            Controller = new PeopleController();
        }

        [Test, Order(1)]
        public void GetAllPeople()
        {
            List<Person> people = Controller.Get();

            Console.WriteLine("GetAllPeople found " + people.Count.ToString() + " people:");

            foreach (Person p in people)
            {
                Console.WriteLine(p.Email);
            }

            Assert.IsTrue(
                people.Count == 8 &&
                people.Any(person => String.IsNullOrEmpty(person.Email) == false)
            );
        }

        [Test, Order(2)]
        public void GetSpecificPerson()
        {
            Person person = Controller.Get("victoriakidd@pharmex.com");

            Assert.IsTrue(
                person != null &&
                person.Name == "Victoria Kidd"
            );
        }

        [Test, Order(3)]
        public void PutExistingPerson()
        {
            // i.e. Bonnie gets married and changes her name:
            Person p = new Person()
            {
                Name = "Bonnie Mercer",
                Gender = "female",
                Company = "COMVEX",
                Email = "bonniesingleton@comvex.com",
                Phone = "+1 (943) 407-3343",
                Address = "237 Wolcott Street, Vicksburg, Alaska, 8183",
                About = "Pariatur ea occaecat consectetur magna in nostrud amet veniam reprehenderit ut aute proident ea in. Veniam incididunt labore minim sint do sunt velit mollit irure aliqua reprehenderit. Magna exercitation laborum ea labore cillum minim nulla aute id laboris. Anim nulla qui adipisicing adipisicing labore minim sunt ea mollit ea sunt commodo enim reprehenderit. Deserunt excepteur occaecat nisi exercitation quis.\r\n"
            };

            Controller.Put(p);

            Assert.IsTrue(Controller.Get("bonniesingleton@comvex.com").Name == "Bonnie Mercer");
        }

        [Test, Order(4)]
        public void PutNewPerson()
        {
            Person p = new Person()
            {
                Name = "John Doe",
                Gender = "male",
                Company = "COMVEX",
                Email = "johndoe@gmail.com",
                Phone = "+1 (321) 425-9384",
                Address = "123 Fake Street, Vicksburg, Alaska, 10293",
                About = "Pariatur ea occaecat consectetur magna in nostrud amet veniam reprehenderit ut aute proident ea in. Veniam incididunt labore minim sint do sunt velit mollit irure aliqua reprehenderit. Magna exercitation laborum ea labore cillum minim nulla aute id laboris. Anim nulla qui adipisicing adipisicing labore minim sunt ea mollit ea sunt commodo enim reprehenderit. Deserunt excepteur occaecat nisi exercitation quis.\r\n"
            };

            Controller.Put(p);

            Assert.IsTrue(Controller.Get("johndoe@gmail.com") != null);
        }

        [Test, Order(5)]
        public void PostPerson()
        {
            Person p = new Person()
            {
                Name = "John Doe",
                Gender = "male",
                Company = "COMVEX",
                Email = "johndoe@gmail.com",
                Phone = "+1 (321) 425-9384",
                Address = "123 Fake Street, Vicksburg, Alaska, 10293",
                About = "Pariatur ea occaecat consectetur magna in nostrud amet veniam reprehenderit ut aute proident ea in. Veniam incididunt labore minim sint do sunt velit mollit irure aliqua reprehenderit. Magna exercitation laborum ea labore cillum minim nulla aute id laboris. Anim nulla qui adipisicing adipisicing labore minim sunt ea mollit ea sunt commodo enim reprehenderit. Deserunt excepteur occaecat nisi exercitation quis.\r\n"
            };

            Controller.Post(p);

            Assert.IsTrue(Controller.Get("johndoe@gmail.com") != null);
        }

        [Test, Order(6)]
        public void DeletePerson()
        {
            Controller.Delete("odonnellpotts@comveyor.com");
            Assert.IsTrue(Controller.Service.People.Count == 7);
        }

        [TearDown]
        public void RefreshPersistenceLayer()
        {
            try
            {
                Console.WriteLine("Refreshing people.json at " + Controller.Service.JsonPath + " with new JSON file at " + BackupJsonPath + ".");
                Controller.Service.OverwriteJson(BackupJsonPath);
                Console.WriteLine("people.json data store successfully refreshed.");
            }
            catch
            {
                Console.WriteLine("Error: There was an error refreshing the people.json data store.");
            }
        }
    }
}
