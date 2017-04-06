using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDeploy.Models;

namespace WebDeploy.ServiceAgent
{
    public class ServiceAgent : IServiceAgent
    {
        public List<Product> GetAllProducts()
        {
            var list = new List<Product>()
            {
            new Product {Name= "Rebok Shoes", Sales= "351", Price="7551" },
            new Product {Name= "Nike T shirts", Sales= "352", Price="7552" },
            new Product {Name= "Adidas Jacket", Sales= "353", Price="7553" },
            new Product {Name= "Hiking Shoes", Sales= "354", Price="7554"},
            new Product {Name= "Hero Honda Unicorn", Sales= "355", Price="7555" },
            new Product {Name= "Honda City", Sales= "356", Price="7556" },
            new Product {Name= "BMW", Sales= "357", Price="7557" },
            new Product {Name= "Well-Travelled Kitten", Sales= "358", Price="7558" },
            new Product {Name= "Adidas", Sales= "359", Price="7559" }
         };
            return list;
        }
        
    }
}
