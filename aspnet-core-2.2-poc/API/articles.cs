using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Reflection;
using static System.IO.DirectoryInfo;


namespace aspnetcoreapp.API
{

    public class ArticleContext : DbContext
    {
        public string ParentDirectoryPath() 
        {
            DirectoryInfo executingAssembly = new DirectoryInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
            DirectoryInfo executingAssemblyParentDirectory = executingAssembly.Parent;
            return executingAssemblyParentDirectory.Name;
        }

        public SQLiteConnection SqliteConnection() {
            AppDomain.CurrentDomain.SetData("DataDirectory", this.ParentDirectoryPath());
            return new System.Data.SQLite.SQLiteConnection("Data Source=|DataDirectory|/database/db.sqlite");        
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly ArticleContext _context;

        public ArticleController(ArticleContext context)
        {
            _context = context;

            // if (_context.TodoItems.Count() == 0)
            // {
            //     // Create a new TodoItem if collection is empty,
            //     // which means you can't delete all TodoItems.
            //     _context.TodoItems.Add(new TodoItem { Name = "Item1" });
            //     _context.SaveChanges();
            // }
        }
    }
}