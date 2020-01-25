using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.Common;
using System.Reflection;
using static System.IO.DirectoryInfo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace aspnetcoreapp.API
{

    [Route("api/articles/get")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private string ParentDirectoryPath() 
        {
            // note: this is ugly and in the real world it would be hard-coded in a config file
            return Directory.GetParent(Directory.GetParent(Directory.GetParent(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
            ).ToString()).ToString()).ToString();
        }

        private SQLiteConnection SqliteConnection() {
            return new System.Data.SQLite.SQLiteConnection(
                String.Format("Data Source={0}/database/db.sqlite", this.ParentDirectoryPath())
            );        
        }

        public string GetArticles()
        {
            var articles = new List<Object>();

            Console.Write(this.SqliteConnection().ToString());

            using (var s = this.SqliteConnection()) {

                Console.WriteLine("ERROR: The connection string is invalid: " + s.ConnectionString);

                try 
                {
                    s.Open();
                }
                catch 
                {
                    Console.WriteLine("ERROR: The connection string is invalid: " + s.ConnectionString);
                }

                string getArticlesSqlStatement = "SELECT * FROM articles LIMIT 20";

                System.Data.SQLite.SQLiteCommand sqlCommand = new SQLiteCommand(getArticlesSqlStatement, s);
                System.Data.SQLite.SQLiteDataReader sqliteDataReader = sqlCommand.ExecuteReader();

                while (sqliteDataReader.Read()) 
                {
                    articles.Add(
                        new {
                            Id = sqliteDataReader[0].ToString(),             
                            Title = sqliteDataReader[1].ToString(),                                
                            Url = sqliteDataReader[2].ToString(),                            
                            Points = sqliteDataReader[3].ToString(),                            
                            TimeCreated = sqliteDataReader[4].ToString()                                           
                        }
                    );
                }

                s.Close();
            }

            return JsonConvert.SerializeObject(articles, Formatting.Indented);
        }
    }
}