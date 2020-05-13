using System;
using System.Collections.Generic;

namespace CoronavirusCashFlow.Model.Assets
{
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