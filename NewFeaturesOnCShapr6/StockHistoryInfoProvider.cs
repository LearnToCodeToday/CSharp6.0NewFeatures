using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NewFeaturesOnCShapr6
{
    public class StockHistoryInfoProvider
    {
        public Dictionary<string, List<StockInfo>> GetStockInformationByStockSymbol(string symbol)
        {
            var stocks = getAllStocksWithCSharp6Point0Version();



            if (stocks.Keys.Contains(symbol)) {

                return
                    stocks.Where(stock => stock.Key == symbol).ToDictionary(key => key.Key, value => value.Value);
            }

            throw new ArgumentException("Stock Symbol is not found ");

        }

        private Dictionary<string, List<StockInfo>> getAllStocksWithCSharp6Point0Version()
        {
            Dictionary<string, List<StockInfo>> stocksInfo = new Dictionary<string, List<StockInfo>>();

            stocksInfo["AAPL"] =  GetStockInfoUsingRosylnCompiler("AAPL");
            stocksInfo["BAC"] = GetStockInfoUsingRosylnCompiler("BAC");
            stocksInfo["AMBA"] = GetStockInfoUsingRosylnCompiler("AMBA");
            stocksInfo["GILD"] = GetStockInfoUsingRosylnCompiler("GILD");
            stocksInfo["FB"] = GetStockInfoUsingRosylnCompiler("FB");
            stocksInfo["TWTR"] = GetStockInfoUsingRosylnCompiler("TWTR");
            stocksInfo["DIS"] = GetStockInfoUsingRosylnCompiler("DIS");

            return stocksInfo;
        }

      

        private List<StockInfo> GetStockInfoUsingRosylnCompiler(string stockSymbol)
        {

            var codeFileName = File.ReadAllText("StockDataParser.txt");
            var syntaxTree = SyntaxFactory.ParseSyntaxTree(codeFileName);

            // Create Compilation
            var options = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary);
            var reference = MetadataReference.CreateFromFile(typeof(object).Assembly.Location);

            var thisAssemblyReference = MetadataReference.CreateFromFile(typeof(StockInfo).Assembly.Location);

            var linQAssemblyRefernce = MetadataReference.CreateFromFile(typeof(System.Linq.IOrderedQueryable).Assembly.Location);
            var compilation = CSharpCompilation.Create("StockDataParser")
                .WithOptions(options)
                .AddSyntaxTrees(syntaxTree)
                .AddReferences(reference)
                .AddReferences(thisAssemblyReference)

                .AddReferences(linQAssemblyRefernce);

            // Show Diagnostics
            var diagnostics = compilation.GetDiagnostics();
            foreach (var item in diagnostics)
            {
                Console.WriteLine(item.ToString());
            }

            // Execute Code

            string fullClassName = "NewFeaturesOnCShapr6.StockDataParser";
            using (var stream = new MemoryStream())
            {
                compilation.Emit(stream);
                var assembly = Assembly.Load(stream.GetBuffer());
                var type = assembly.GetType(fullClassName);
                dynamic stockInfo = Activator.CreateInstance(type);
                return stockInfo.GetStockInfoByStockSymbol(stockSymbol);
            }
        }

    }
}
