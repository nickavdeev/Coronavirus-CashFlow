using System;
using System.Collections.Generic;

namespace CoronavirusCashFlow.Model.Liabilities
{
    public class SocialNeed : Liability
    {
        private SocialNeed(string title, double cost, double expense, int hours) : base(title, cost, expense, hours) {}

        public static Liability GetSocialNeed(string title) => SocialNeeds[title];
        private static readonly Dictionary<string, Liability> SocialNeeds = new Dictionary<string, Liability>
        {
            // Социальные потребности
            {"Своя квартира", new SocialNeed("Своя квартира", 2500000, new Random().Next(5, 7) * 1000, 0)},
            {"Связь и интернет", new SocialNeed("Связь и интернет", 0, new Random().Next(5, 9) * 100, 0)},
            {"Продукты", new SocialNeed("Продукты", 0, new Random().Next(2, 5) * 1000, 0)},
            {"Транспорт", new SocialNeed("Транспорт", 0, new Random().Next(1, 2) * 1000, 0)},
            {"Подписка Рандекс.Музыка", new SocialNeed("Подписка Рандекс.Музыка", 0, 169, 0)},
            {"Подписка Metflix", new SocialNeed("Подписка Metflix", 0, 2300, 0)},
        };
    }
}