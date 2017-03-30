using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class CompanyStockModel
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public double StockPrice { get; set; }
        public double GainPercentage { get; set; }
        public string Description { get; set; }
        public string OfficeAddress { get; set; }
        public string EmailID { get; set; }
        public string CEOName { get; set; }
    }
}
