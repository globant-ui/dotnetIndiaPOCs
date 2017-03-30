using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessServices
{
    public interface IBusinessService
    {
        List<CompanyStockModel> GetTop5Stocks();
        List<CompanyStockModel> GetAllStocks();
        CompanyStockModel GetCompanyInfo(int CompanyID);
    }
}
