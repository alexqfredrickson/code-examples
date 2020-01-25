using DAL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;

namespace DAL
{
    /// <summary>
    /// Represents a data access layer to query a mock persistence layer.  Uses a JSON file in lieu of a database.
    /// </summary>
    public class PersonService
    {
        public string JsonPath = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\DAL\people.json"; // path relative to NUnit console runner

        public List<Person> People = new List<Person>();

        /// <summary>
        /// Saves People to the JSON store.
        /// </summary>
        public void SavePeopleToJson()
        {
            using (StreamWriter sw = new StreamWriter(JsonPath))
            {
                string newJson = JsonConvert.SerializeObject(People);
                sw.Write(newJson);
            }
        }

        /// <summary>
        /// Overwrites the JSON store with a new JSON.
        /// </summary>
        public void OverwriteJson(string pathToBackupJson)
        {
            string backupJsonData = "";

            using (StreamReader sr = new StreamReader(pathToBackupJson))
            {
                backupJsonData = sr.ReadToEnd();
            }

            using (StreamWriter sw = new StreamWriter(JsonPath))
            {
                sw.Write(backupJsonData);
            }
        }

        public PersonService()
        {
            using (StreamReader r = new StreamReader(JsonPath))
            {
                string json = r.ReadToEnd();
                this.People = JsonConvert.DeserializeObject<List<Person>>(json);
            }
        }
    }
}
