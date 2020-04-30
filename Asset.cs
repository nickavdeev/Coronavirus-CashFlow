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
        public static readonly List<string> Companies = new List<string>
        {
            "Gilead Sciences", 
            "Netflix"
        };
        private Stock(string title, double cost, double income, int hours) : base(title, cost, income, hours)
        {
            Title = "Акции " + title;
        }
        
        public static Asset GetStock(string title) => Stocks[title];
        private static readonly Dictionary<string, Asset> Stocks = new Dictionary<string, Asset>()
        {
            // Акции компаний
            {Companies[0], new Stock(Companies[0], new Random().Next(200, 500), new Random().Next(10, 40), 0)},
            {Companies[1], new Stock(Companies[1], new Random().Next(200, 500), new Random().Next(10, 40), 0)},
        };
    }
    
    public class Work : Asset
    {
        public static readonly List<string> Professions = new List<string>
        {
            "Программист C#", 
            "Журналист"
        };
        
        private Work(string title, double income, int hours) : base(title, income, hours)
        {
            Title = "Работа: " + title;
        }
        
        public static Asset GetWork(string title) => Works[title];
        private static readonly Dictionary<string, Asset> Works = new Dictionary<string, Asset>
        {
            // Варианты работы
            {Professions[0], new Work(Professions[0], new Random().Next(20000, 30000), 120)},
            {Professions[1], new Work(Professions[1], new Random().Next(20000, 30000), 100)},
        };
    }
}