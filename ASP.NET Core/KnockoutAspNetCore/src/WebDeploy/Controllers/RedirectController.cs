using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebDeploy.ServiceAgent;
using WebDeploy.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebDeploy.Controllers
{
    public class RedirectController : Controller
    {
        private readonly IServiceAgent _serviceAgent;

        public RedirectController(IServiceAgent serviceAgent)
        {
            _serviceAgent = serviceAgent;
           
        }// GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public List<Product> GetAllData()
        {
            return _serviceAgent.GetAllProducts();
        }
    }
}
