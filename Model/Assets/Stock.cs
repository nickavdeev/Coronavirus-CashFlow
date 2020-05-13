using System;
using System.Collections.Generic;

namespace CoronavirusCashFlow.Model.Assets
{
    public class Stock : Asset
    {
        private Stock(string title, double cost, double income, int hours) : base(title, cost, income, hours)
        {
            Title = "Акции " + title;
        }
        
        public static Asset GetStock(string title) => Stocks[title];
        internal static readonly Dictionary<string, Asset> Stocks = new Dictionary<string, Asset>()
        {
            // Акции компаний
            {"Gilead Sciences", new Stock("Gilead Sciences", new Random().Next(200, 500), new Random().Next(10, 40), 0)},
            {"Metflix", new Stock("Metflix", new Random().Next(200, 500), new Random().Next(10, 40), 0)},
            {"Zoom", new Stock("Zoom", new Random().Next(100, 200), new Random().Next(0, 20), 0)},
        };
    }
}