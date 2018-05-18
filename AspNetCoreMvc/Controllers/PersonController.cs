using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreMvc.Models;

namespace AspNetCoreMvc.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            var people = new List<Person>();
            people.Add(new Person { Name = "Cody" });
            people.Add(new Person { Name = "Reid" });
            people.Add(new Person { Name = "Chris" });
            people.Add(new Person { Name = "Trey" });
            people.Add(new Person { Name = "Brandon" });
            people.Add(new Person { Name = "Stephen" });
            return View(people);
        }
        public IActionResult Edit()
        {
            var people = new List<Person>();
            people.Add(new Person { Name = "Cody" });
            people.Add(new Person { Name = "Reid" });
            people.Add(new Person { Name = "Chris" });
            people.Add(new Person { Name = "Trey" });
            people.Add(new Person { Name = "Brandon" });
            people.Add(new Person { Name = "Stephen" });
            return View(people);
        }
        public IActionResult Create()
        {
            var people = new List<Person>();
            people.Add(new Person { Name = "Cody" });
            people.Add(new Person { Name = "Reid" });
            people.Add(new Person { Name = "Chris" });
            people.Add(new Person { Name = "Trey" });
            people.Add(new Person { Name = "Brandon" });
            people.Add(new Person { Name = "Stephen" });
            return View(people);
        }
    }
}