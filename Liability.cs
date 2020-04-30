using System;
using System.Collections.Generic;

namespace CoronavirusCashFlow
{
    public enum LiabilityType
    {
        SocialNeed,
    }
    
    public class Liability
    {
        public readonly string Title;
        public readonly double Cost;
        public readonly double Expense;
        public readonly int Hours;

        internal Liability(string title, double cost, double expense, int hours)
        {
            Title = title;
            Cost = cost;
            Expense = expense;
            Hours = hours;
        }
    }

    public class SocialNeed : Liability
    {
        public static readonly List<string> Needs = new List<string>
        {
            "Своя квартира",
            "Красная Ferarri"
        };

        private SocialNeed(string title, double cost, double expense, int hours) : base(title, cost, expense, hours) {}

        public static Liability GetSocialNeed(string title) => SocialNeeds[title];
        private static readonly Dictionary<string, Liability> SocialNeeds = new Dictionary<string, Liability>
        {
            // Социальные потребности
            {Needs[0], new SocialNeed(Needs[0], 2500000, new Random().Next(5000, 7000), 0)},
            {Needs[1], new SocialNeed(Needs[1], 8000000, new Random().Next(5000, 7000), 10)},
        };
    }
}