using System;
using System.Collections.Generic;

namespace CoronavirusCashFlow.Model.Assets
{
    public class Stock : Asset
    {
        private Stock(string title, double cost, double income, int hours) : base(title, cost, income, hours) { }
        
        public static Asset GetStock(string title) => Stocks[title];
        internal static readonly Dictionary<string, Asset> Stocks = new Dictionary<string, Asset>()
        {
            // Акции компаний
            {"Gilead", new Stock("Gilead", new Random().Next(200, 500), new Random().Next(10, 40), 0)},
            {"Metflix", new Stock("Metflix", new Random().Next(200, 500), new Random().Next(10, 40), 0)},
            {"Zuum", new Stock("Zuum", new Random().Next(100, 200), new Random().Next(0, 20), 0)},
            {"Газнефть", new Stock("Газнефть", new Random().Next(100, 200), new Random().Next(0, 20), 0)},
            {"Рандекс", new Stock("Рандекс", new Random().Next(200, 300), new Random().Next(0, 20), 0)},
        };
    }
}