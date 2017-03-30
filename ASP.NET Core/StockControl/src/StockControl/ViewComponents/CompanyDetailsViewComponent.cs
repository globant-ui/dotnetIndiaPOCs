using BusinessServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockControl.ViewComponents
{
    public class CompanyDetailsViewComponent : ViewComponent
    {
        private readonly IBusinessService _businessService;

        public CompanyDetailsViewComponent(IBusinessService businessService)
        {
            _businessService = businessService;
        }

        public IViewComponentResult Invoke(int CompanyID)
        {
            return View(_businessService.GetCompanyInfo(CompanyID));
        }
    }
}
  