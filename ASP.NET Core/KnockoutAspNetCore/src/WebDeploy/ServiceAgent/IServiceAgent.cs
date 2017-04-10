using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDeploy.Models;

namespace WebDeploy.ServiceAgent
{
    public interface IServiceAgent
    {
        List<Product> GetAllProducts();
        List<Product> GetPrice();
    }
}
