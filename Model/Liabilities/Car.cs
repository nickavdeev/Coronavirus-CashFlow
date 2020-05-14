using System.Collections.Generic;

namespace CoronavirusCashFlow.Model.Liabilities
{
    public class Car : Liability
    {
        public static readonly Liability TransportTax = Tax.GetTax("Транспортный налог");
        
        private Car(string title, double cost, double expense, int hours) : base(title, cost, expense, hours) { }
        
        public static Liability GetCar(string title) => Cars[title];
        private static readonly Dictionary<string, Liability> Cars = new Dictionary<string, Liability>
        {
            // Автомобили
            {"Volkswagen Polo", new Car("Volkswagen Polo", 700000, 1600, 18)},
            {"Porsche Cayman", new Car("Porsche Cayman", 5000000, 7000, 20)},
        };
    }
}