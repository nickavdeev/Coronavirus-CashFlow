using System;
using System.Collections.Generic;

namespace CoronavirusCashFlow
{
    public enum LiabilityType
    {
        SocialNeed,
        Car
    }
    
    public class Liability
    {
        public string Title;
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
        private SocialNeed(string title, double cost, double expense, int hours) : base(title, cost, expense, hours) {}

        public static Liability GetSocialNeed(string title) => SocialNeeds[title];
        private static readonly Dictionary<string, Liability> SocialNeeds = new Dictionary<string, Liability>
        {
            // Социальные потребности
            {"Своя квартира", new SocialNeed("Своя квартира", 2500000, new Random().Next(5, 7) * 1000, 0)},
        };
    }

    public class Car : Liability
    {
        private Car(string title, double cost, double expense, int hours) : base(title, cost, expense, hours)
        {
            Title = "Автомобиль: " + title;
        }
        public static Liability GetCar(string title) => Cars[title];
        private static readonly Dictionary<string, Liability> Cars = new Dictionary<string, Liability>
        {
            // Автомобили
            {"Volkswagen Polo", new Car("Volkswagen Polo", 700000, 2000, 18)},
            {"Porsche Cayman", new Car("Porsche Cayman", 5000000, 7000, 20)},
        };
    }
}