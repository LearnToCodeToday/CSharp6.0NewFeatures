using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFeaturesOnCShapr6
{
    public static class NewDictionaryInitializer
    {

        public static Dictionary<string, List<StockInfo>> GetAppleStockInformationWitNewDictionaryInitializer1()
        {
            var appleStocks = new Dictionary<string, List<StockInfo>>();

            appleStocks["AAPL"] = new List<StockInfo> {
                new StockInfo{Date = "10/09/2015",  Close=  "101.27", DayHigh="  101.8", DayLow="   99.45", OpenAt="   100.65", Volume="  8,620,028" },
                new StockInfo {Date = "10/08/2015",  Close=  "100.03", DayHigh="101.16", DayLow="98.07", OpenAt="   100.65", Volume="11,819,170" }
            };


            return appleStocks;
        }
        public static Dictionary<string, List<StockInfo>> GetAppleStockInformationWithoutNewDictionaryInitializer()
        {
            var appleStocks = new Dictionary<string, List<StockInfo>>
            {
                {
                    "APPL", new List<StockInfo>
                        {   new StockInfo{Date = "10/09/2015",  Close=  "101.27", DayHigh="  101.8", DayLow="   99.45", OpenAt="   100.65", Volume="  8,620,028"},
                            new StockInfo{Date = "10/08/2015",  Close=  "100.03", DayHigh="101.16", DayLow="98.07", OpenAt="   100.65", Volume="11,819,170"}
                        }
                }

            };


            return appleStocks;

           
        }
    }
}
