using System.Collections.Generic;

namespace CoronavirusCashFlow.Model.Liabilities
{
    public class Tax : Liability
    {
        private Tax(string title, double cost, double expense, int hours) : base(title, cost, expense, hours) {}
        
        public static Liability GetTax(string title) => Taxes[title];
        private static readonly Dictionary<string, Liability> Taxes = new Dictionary<string, Liability>
        {
            // Налоги
            {"Транспортный налог", new Tax("Транспортный налог", 0, 100, 0)},
        };
    }
}