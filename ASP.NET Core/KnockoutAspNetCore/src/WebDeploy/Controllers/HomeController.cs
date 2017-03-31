using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebDeploy.Models;
using WebDeploy.Helper;

namespace WebDeploy.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
        [HttpPost]
        public Employee SaveEmployee([FromBody] Employee emp)
        {
            //Save Employee here
            return emp;
        }

        public IActionResult Test()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
            //return RedirectToAction("Index1", "Redirect");
        }

    }
}
