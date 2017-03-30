using BusinessServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockControl.ViewComponents
{
    public class TopStocksViewComponent : ViewComponent
    {
        private readonly IBusinessService _businessService;

        public TopStocksViewComponent(IBusinessService businessService)
        {
            _businessService = businessService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_businessService.GetTop5Stocks().ToList());
        }
        
    }
}
