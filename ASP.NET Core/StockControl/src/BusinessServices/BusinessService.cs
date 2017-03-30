using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessEntities;
using DataRepository;

namespace BusinessServices
{
    public class BusinessService : IBusinessService
    {
        public List<CompanyStockModel> GetTop5Stocks()
        {
            Data objData = new Data();
            var listStocks = objData.GetData().OrderByDescending(i => i.GainPercentage).Take(5).ToList();
            return listStocks;
        }

        public CompanyStockModel GetCompanyInfo(int companyID)
        {
            Data objData = new Data();
            List<CompanyStockModel> listStocks = objData.GetData();
            CompanyStockModel stockModel = new CompanyStockModel();
            stockModel = listStocks.Find(item => item.CompanyID == companyID);
            return stockModel;
        }

        public List<CompanyStockModel> GetAllStocks()
        {
            Data objData = new Data();
            List<CompanyStockModel> listStocks = objData.GetData().OrderBy(i => i.CompanyName).ToList();
            return listStocks;
        }
    }
}
