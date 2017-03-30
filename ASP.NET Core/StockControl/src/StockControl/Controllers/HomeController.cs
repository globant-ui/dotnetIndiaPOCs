using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessServices;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace StockControl.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBusinessService _businessService;
        private readonly ILogger<HomeController> _log;

        public HomeController(IBusinessService businessService, ILogger<HomeController> log)
        {
            _businessService = businessService;
            _log = log;
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true, Duration = 0)]
        public IActionResult Index()
        {
            //int w = 0;
            //int q = 1 / w;
            _log.LogInformation("This is Index View!");          
            //return View(_businessService.GetTop5Stocks().ToList());            
            return View();
            
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true, Duration = 0)]
        public IActionResult GetTopStocks()
        {            
            ModelState.Clear();
                        
            //return this.PartialView("TopStocks", _businessService.GetTop5Stocks().ToList());
            return ViewComponent("TopStocks");
        }

        public IActionResult Details(int? id)
        {
            //return View();

            //return ViewComponent("CompanyDetails", new { CompanyID = id } );
            ViewBag.id = id;
            return View("Details");
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true, Duration = 0)]
        public IActionResult AllStocks()
        {
            ModelState.Clear();
            //To check data passing
            //ViewBag.ViewC = "1234566778";
            //ViewBag.SessionData = HttpContext.Session.GetString("SessionData");
            return View("AllStocks");
        }


        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true, Duration = 0)]
        public IActionResult AllStocksComponent()
        {
            ModelState.Clear();
            //To check data passing
            //HttpContext.Session.SetString("SessionHome", "This is Session Data from HomeController");
            return ViewComponent("AllStocks");
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
    }
}
