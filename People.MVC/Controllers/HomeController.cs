using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using People.MVC.Models;
using Microsoft.Extensions.Logging;
using PeopleLibrary;

namespace People.MVC.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=People;Integrated Security=True;";
        public IActionResult Index()
        {
            PersonDB PersonDB= new PersonDB(_connectionString);
            List<Person> people = PersonDB.GetAll();
            return View(people);
        }
        public IActionResult AddPerson()
        {
            return View();
        }

       public IActionResult SubmitPeople(List<Person> Person)
        {
            PersonDB personDB = new PersonDB(_connectionString);
            foreach(Person p in Person)
            {
                personDB.AddPerson(p);
            }
            return Redirect("/Home/Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
