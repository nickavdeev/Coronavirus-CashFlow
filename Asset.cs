using System;
using System.Collections.Generic;

namespace CoronavirusCashFlow
{
    public enum AssetType
    {
        Work,
        Stock
    }
    
    public class Asset
    {
        // private readonly AssetType AssetType;
        public string Title;
        public readonly double Cost;
        public readonly double Income;
        public readonly int Hours;

        internal Asset(string title, double cost, double income, int hours)
        {
            //AssetType = AssetType.Stock;
            Title = title;
            Cost = cost;
            Income = income;
            Hours = hours;
        }
        
        internal Asset(string title, double income, int hours)
        {
            // AssetType = AssetType.Work;
            Title = title;
            Cost = 0;
            Income = income;
            Hours = hours;
        }
    }

    public class Stock : Asset
    {
        private Stock(string title, double cost, double income, int hours) : base(title, cost, income, hours)
        {
            Title = "Акции " + title;
        }
        
        public static Asset GetStock(string title) => Stocks[title];
        private static readonly Dictionary<string, Asset> Stocks = new Dictionary<string, Asset>()
        {
            // Акции компаний
            {"Gilead Sciences", new Stock("Gilead Sciences", new Random().Next(200, 500), new Random().Next(10, 40), 0)},
            {"Netflix", new Stock("Netflix", new Random().Next(200, 500), new Random().Next(10, 40), 0)},
            {"Zoom", new Stock("Zoom", new Random().Next(100, 200), new Random().Next(0, 20), 0)},
        };
    }
    
    public class Work : Asset
    {
        private Work(string title, double income, int hours) : base(title, income, hours)
        {
            Title = "Работа: " + title;
        }
        
        public static Asset GetWork(string title) => Works[title];
        private static readonly Dictionary<string, Asset> Works = new Dictionary<string, Asset>
        {
            // Варианты работы
            {"Программист", new Work("Программист", new Random().Next(20, 30) * 1000, 120)},
            {"Журналист", new Work("Журналист", new Random().Next(20, 30) * 1000, 100)},
        };
    }
}