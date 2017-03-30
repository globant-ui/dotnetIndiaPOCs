using BusinessServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockControl.ViewComponents
{
    public class AllStocksViewComponent : ViewComponent
    {
        private readonly IBusinessService _businessService;

        public AllStocksViewComponent(IBusinessService businessService)
        {
            _businessService = businessService;
        }

        public IViewComponentResult Invoke()
        {
            //To check data passing
            //ViewBag.VC = "VC test Data from Component.cs";
            //HttpContext.Session.SetString("SessionData", "This is Session Data");

            //ViewBag.SessionHome = HttpContext.Session.GetString("SessionHome");

            return View(_businessService.GetAllStocks().ToList());
        }
    }
}
