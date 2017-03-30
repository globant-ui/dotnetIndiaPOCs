using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataRepository
{
    public class Data
    {
        

        public List<CompanyStockModel> GetData()
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
            double basepriceMarutiSuzuki = 6191.00;
            double basepriceTCS = 2530.85;
            double basepriceCipla = 597.35;
            double basepriceWipro = 503.50;
            double basepriceBhartiAirtel = 344.60;
            double basepriceHeroMotocorp = 3349.90;
            double basepriceTataMotors = 476.00;

            List<CompanyStockModel> listStocks = new List<CompanyStockModel>
            {
                new CompanyStockModel { CompanyID=1, CompanyName="HDFC Bank", CEOName="Aditya Puri", Description="HDFC Bank is an Indian banking and financial services company headquartered in Mumbai, Maharashtra. It has 90,421 employees and has a presence in Bahrain, Hong Kong and Dubai. HDFC Bank is India’s second-largest private sector lender by assets.", EmailID="support@hdfc.com", GainPercentage=r1, StockPrice = (basepriceHDFC +  (basepriceHDFC * r1/100)), OfficeAddress="Mumbai"},
                new CompanyStockModel { CompanyID=2, CompanyName="ITC", CEOName="Yogesh Chander Deveshwar", Description="ITC Limited or ITC is an Indian conglomerate headquartered in Kolkata, West Bengal. Its diversified business includes five segments: Fast-Moving Consumer Goods, Hotels, Paperboards & Packaging, Agri Business & Information Technology.", EmailID="support@itc.com", GainPercentage=r2, StockPrice = (basepriceITC +  (basepriceITC * r2/100)), OfficeAddress="Kolkata"},
                new CompanyStockModel { CompanyID=3, CompanyName="Axis Bank", CEOName="Shikha Sharma", Description="AxisBank is the third largest of the private-sector banks in India offering a comprehensive suite of financial products. The bank has its head office in Mumbai and Registered office in Ahmedabad.", EmailID="support@axis.com", GainPercentage=r3, StockPrice = (basepriceAxisBank +  (basepriceAxisBank * r3/100)), OfficeAddress="Mumbai"},
                new CompanyStockModel { CompanyID=4, CompanyName="Maruti Suzuki", CEOName="Kenichi Ayukawa", Description="Maruti Suzuki India Limited, formerly known as Maruti Udyog Limited, is an automobile manufacturer in India. It is a subsidiary of Japanese automobile and motorcycle manufacturer Suzuki Motor Corporation.", EmailID="support@suzuki.com", GainPercentage=r4, StockPrice = (basepriceMarutiSuzuki +  (basepriceMarutiSuzuki * r4/100)), OfficeAddress="New Delhi"},
                new CompanyStockModel { CompanyID=5, CompanyName="TCS", CEOName="Rajesh Gopinathan", Description="Tata Consultancy Services Limited is an Indian multinational information technology service, consulting and business solutions company Headquartered in Mumbai, Maharashtra. It is a subsidiary of the Tata Group and operates in 46 countries.", EmailID="support@tcs.com", GainPercentage=r5, StockPrice = (basepriceTCS +  (basepriceTCS * r5/100)), OfficeAddress="Mumbai"},
                new CompanyStockModel { CompanyID=6, CompanyName="Cipla", CEOName="Subhanu Saxena", Description="Cipla Limited is an Indian multinational pharmaceutical and biotechnology company, headquartered in Mumbai, India.", EmailID="support@cipla.com", GainPercentage=r6, StockPrice = (basepriceCipla +  (basepriceCipla * r6/100)), OfficeAddress="Mumbai"},
                new CompanyStockModel { CompanyID=7, CompanyName="Wipro", CEOName="Abidali Neemuchwala", Description="Wipro Limited is an Indian Information Technology Services corporation headquartered in Bangalore, India. In 2013, Wipro demerged its non-IT businesses into a separate companies to bring in more focus on independent businesses.", EmailID="support@wipro.com", GainPercentage=r7, StockPrice = (basepriceWipro +  (basepriceWipro * r7/100)), OfficeAddress="Bengaluru"},
                new CompanyStockModel { CompanyID=8, CompanyName="Bharti Airtel", CEOName="Gopal Vittal", Description="Bharti Airtel Limited is an Indian global telecommunications services company based in New Delhi, India. It operates in 18 countries across South Asia and Africa.", EmailID="support@airtel.com", GainPercentage=r8, StockPrice = (basepriceBhartiAirtel +  (basepriceBhartiAirtel * r8/100)), OfficeAddress="New Delhi"},
                new CompanyStockModel { CompanyID=9, CompanyName="Hero Motocorp", CEOName="Pawan Munjal", Description="Hero Motocorp Ltd., formerly Hero Honda, is an Indian motorcycle and scooter manufacturer based in New Delhi, India. The company is the largest two-wheeler manufacturer in India where it has a market share of about 46% in the two-wheeler category.", EmailID="support@heromotocorp.com", GainPercentage=r9, StockPrice = (basepriceHeroMotocorp +  (basepriceHeroMotocorp * r9/100)), OfficeAddress="New Delhi"},
                new CompanyStockModel { CompanyID=10, CompanyName="Tata Motors", CEOName="Guenter Butschek", Description="Tata Motors Limited is an Indian multinational automotive manufacturing company headquartered in Mumbai, India, and a member of the Tata Group.", EmailID="support@tatamotors.com", GainPercentage=r10, StockPrice = (basepriceTataMotors +  (basepriceTataMotors * r10/100)), OfficeAddress="Mumbai"}

            };

            return listStocks;

        }

        

    }
}
