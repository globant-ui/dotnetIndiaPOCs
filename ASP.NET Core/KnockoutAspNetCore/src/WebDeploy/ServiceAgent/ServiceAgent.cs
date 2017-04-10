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

        public List<Product> GetPrice()
        {
            Random r = new Random();
            int r1 = r.Next(0, 25);
            int r2 = r.Next(0, 25);
            int r3 = r.Next(0, 25);
            int r4 = r.Next(0, 25);
            int r5 = r.Next(0, 25);
            int r6 = r.Next(0, 25);
            int r7 = r.Next(0, 25);
            int r8 = r.Next(0, 25);
            int r9 = r.Next(0, 25);
            int r10 = r.Next(0, 25);

            double basepriceHDFC = 1426.65;
            double basepriceITC = 280.55;
            double basepriceAxisBank = 515.45;
            //double basepriceMarutiSuzuki = 6191.00;
            //double basepriceTCS = 2530.85;
            //double basepriceCipla = 597.35;
            //double basepriceWipro = 503.50;
            //double basepriceBhartiAirtel = 344.60;
            //double basepriceHeroMotocorp = 3349.90;
            //double basepriceTataMotors = 476.00;

            List<Product> listStocks = new List<Product>
            {
                new Product { Name="HDFC Bank",  Price =Convert.ToString(basepriceHDFC +  (basepriceHDFC * r1/100)), Sales="500"},
                new Product { Name="ITC", Price =Convert.ToString(basepriceITC +  (basepriceITC * r2/100)), Sales="404"},
                new Product { Name="Axis Bank", Price =Convert.ToString(basepriceAxisBank +  (basepriceAxisBank * r3/100)), Sales="4020"}
             };

            return listStocks;

        }
    }
}
