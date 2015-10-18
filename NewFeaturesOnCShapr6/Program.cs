using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFeaturesOnCShapr6
{
    class Program
    {

        private static void AutoPropertyInitializerExample()
        {
            var product = new Product();
            Console.WriteLine(product.ProductId);


            Console.WriteLine(product.ParentProductCategoryId);

            Console.ReadLine();
        }

        static void Main(string[] args)
        {

            loadStockDataByStockSymbol("AAPL");

            Console.ReadLine();
          
        }

        private static void loadStockDataByStockSymbol(string stockTickerSymbol)
        {
            var stockHistoryProvider = new StockHistoryInfoProvider();

            var stockSymbols = stockHistoryProvider.GetStockInformationByStockSymbol("DIS");

            printTickerSymbol(stockSymbols);
        }

       

        private static void printTickerSymbol(Dictionary<string, List<StockInfo>> stockInfos)
        {
            if (stockInfos.Count > 0)
            {
                var stockInformation = stockInfos.Select(dic => dic.Value).SingleOrDefault();

                Console.WriteLine($"{"Date"} {"Day High"} {"Day Low"} {"Open At"} {"Close"} {"Volume"} {"\n"}");

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n");

                foreach (StockInfo sf in stockInformation)
                {
                    var stockInfo = $"{sf.Date} {sf.DayHigh} { sf.DayLow} {sf.OpenAt} {sf.Close} {sf.Volume} {"\n"}";

                    Console.WriteLine(stockInfo);
                }
            }
        }
    }
}
